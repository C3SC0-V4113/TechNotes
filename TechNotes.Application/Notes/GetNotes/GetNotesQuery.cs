using MediatR;

namespace TechNotes.Application.Notes.GetNotes;

public class GetNotesQuery : IRequest<List<NoteResponse>>
{

}
