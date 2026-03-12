using TechNotes.Application.Users;

namespace TechNotes.Application.Notes.TogglePublishedNote;

public class TogglePublishedNoteCommandHandler : ICommandHandler<TogglePublishedNoteCommand, NoteResponse>
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserService _userService;

    public TogglePublishedNoteCommandHandler(INoteRepository noteRepository, IUserService userService)
    {
        _noteRepository = noteRepository;
        _userService = userService;
    }
    public async Task<Result<NoteResponse>> Handle(TogglePublishedNoteCommand request, CancellationToken cancellationToken)
    {
        var currentUserCanEdit = await _userService.CurrentUserCanEditNoteAsync(request.NoteId);
        if (!currentUserCanEdit)
        {
            return Result.Fail<NoteResponse>("You do not have permission to edit this note.");
        }
        var note = await _noteRepository.GetNoteByIdAsync(request.NoteId);
        if (note == null)
        {
            return Result.Fail<NoteResponse>("Note not found or could not be updated.");
        }
        note.IsPublished = !note.IsPublished;
        note.UpdatedAt = DateTime.Now;
        if (note.IsPublished)
        {
            note.PublishedAt = DateTime.Now;
        }
        var updatedNote = await _noteRepository.UpdateNoteAsync(note);
        if (updatedNote == null)
        {
            return Result.Fail<NoteResponse>("Note could not be updated.");
        }
        return updatedNote.Adapt<NoteResponse>();
    }
}
