using TechNotes.Application.Users;

namespace TechNotes.Application.Notes.UpdateNote;

public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand, NoteResponse?>
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserService _userService;

    public UpdateNoteCommandHandler(INoteRepository noteRepository, IUserService userService)
    {
        _noteRepository = noteRepository;
        _userService = userService;
    }

    public async Task<Result<NoteResponse?>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var existingNote = request.Adapt<Note>();
        var currentUserCanEdit = await _userService.CurrentUserCanEditNoteAsync(existingNote.Id);
        if (!currentUserCanEdit)
        {
            return Result.Fail<NoteResponse?>("You do not have permission to edit this note.");
        }
        var updatedNote = await _noteRepository.UpdateNoteAsync(existingNote);
        if (updatedNote == null)
        {
            return Result.Fail<NoteResponse?>("Note not found or could not be updated.");
        }
        return updatedNote.Adapt<NoteResponse>();
    }
}
