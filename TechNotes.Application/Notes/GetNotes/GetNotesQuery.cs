using MediatR;
using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes.GetNotes;

public class GetNotesQuery : IRequest<List<Note>>
{

}
