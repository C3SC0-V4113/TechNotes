using TechNotes.Application.Exceptions;
using TechNotes.Application.Users;
namespace TechNotes.Application.Notes.CreateNote;

public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand, NoteResponse>
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserService _userService;

    public CreateNoteCommandHandler(INoteRepository noteRepository, IUserService userService)
    {
        _noteRepository = noteRepository;
        _userService = userService;
    }

    public async Task<Result<NoteResponse>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newNote = request.Adapt<Note>();
            var userId = await _userService.GetCurrentUserIdAsync();
            if (userId == null)
            {
                return FailNoteCreate();
            }
            var isCurrentUserCanCreateNote = await _userService.CurrentUserCanCreateNoteAsync();
            if (!isCurrentUserCanCreateNote)
            {
                return FailNoteCreate();
            }
            newNote.UserId = userId;
            var createdNote = await _noteRepository.CreateNoteAsync(newNote);
            return createdNote.Adapt<NoteResponse>();
        }
        catch (UserNotAuthorizedException)
        {
            return FailNoteCreate();
        }

    }

    private static Result<NoteResponse> FailNoteCreate()
    {
        return Result.Fail<NoteResponse>("User is not authorized to create a note.");
    }
}