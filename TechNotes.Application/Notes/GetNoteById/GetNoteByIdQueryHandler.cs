namespace TechNotes.Application.Notes.GetNoteById;

public class GetNoteByIdQueryHandler : IQueryHandler<GetNoteByIdQuery, NoteResponse?>
{
    private readonly INoteRepository _noteRepository;
    public GetNoteByIdQueryHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<Result<NoteResponse?>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetNoteByIdAsync(request.Id);
        if (note == null)
        {
            return Result.Fail<NoteResponse?>("Note not found.");
        }
        return note.Adapt<NoteResponse>();
    }
}