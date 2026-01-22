using MediatR;

namespace TechNotes.Application.Notes.DeleteNote;

public class DeleteNoteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
