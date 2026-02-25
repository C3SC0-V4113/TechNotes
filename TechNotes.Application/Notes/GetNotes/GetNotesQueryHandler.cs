using TechNotes.Domain.User;

namespace TechNotes.Application.Notes.GetNotes;

public class GetNotesQueryHandler : IQueryHandler<GetNotesQuery, List<NoteResponse>>
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserRepository _userRepository;
    public GetNotesQueryHandler(INoteRepository noteRepository, IUserRepository userRepository)
    {
        _noteRepository = noteRepository;
        _userRepository = userRepository;
    }
    public async Task<Result<List<NoteResponse>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _noteRepository.GetAllNotesAsync();
        var response = new List<NoteResponse>();
        foreach (var note in notes)
        {
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

            response.Add(noteResponse);
        }
        return response.OrderByDescending(n => n.PublishedAt).ToList();
    }
}
