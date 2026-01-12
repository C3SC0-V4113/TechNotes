using MediatR;

namespace TechNotes.Application.Notes.GetNoteById;

public class GetNoteByIdQuery : IRequest<NoteResponse?>
{
    public int Id { get; set; }
}
