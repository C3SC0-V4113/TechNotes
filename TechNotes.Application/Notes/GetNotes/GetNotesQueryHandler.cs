namespace TechNotes.Application.Notes.GetNotes;

public class GetNotesQueryHandler : IQueryHandler<GetNotesQuery, List<NoteResponse>>
{
    private readonly INoteRepository _noteRepository;
    public GetNotesQueryHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<Result<List<NoteResponse>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _noteRepository.GetAllNotesAsync();
        return notes.Adapt<List<NoteResponse>>();
    }
}
