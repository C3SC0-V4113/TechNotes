
using MediatR;
using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes.GetNotes;

public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<Note>>
{
    private readonly INoteRepository _noteRepository;
    public GetNotesQueryHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<List<Note>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        return await _noteRepository.GetAllNotesAsync();
    }
}
