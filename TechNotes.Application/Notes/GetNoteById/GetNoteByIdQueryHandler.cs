using TechNotes.Domain.User;
namespace TechNotes.Application.Notes.GetNoteById;

public class GetNoteByIdQueryHandler : IQueryHandler<GetNoteByIdQuery, NoteResponse?>
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserRepository _userRepository;
    public GetNoteByIdQueryHandler(INoteRepository noteRepository, IUserRepository userRepository)
    {
        _noteRepository = noteRepository;
        _userRepository = userRepository;
    }
    public async Task<Result<NoteResponse?>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetNoteByIdAsync(request.Id);
        if (note == null)
        {
            return Result.Fail<NoteResponse?>("Note not found.");
        }
        var noteResponse = note.Adapt<NoteResponse>();
        if (note.UserId != null)
        {
            var user = await _userRepository.GetUserByIdAsync(note.UserId);
            noteResponse.UserName = user?.UserName ?? "Unknown User";
        }
        else
        {
            noteResponse.UserName = "Unknown User";
        }
        return noteResponse;
    }
}