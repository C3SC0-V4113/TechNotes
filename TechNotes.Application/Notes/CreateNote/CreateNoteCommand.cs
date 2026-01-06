using MediatR;
using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes.CreateNote;

public class CreateNoteCommand : IRequest<Note>
{
    public required string Title { get; set; }
    public string? Content { get; set; }
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    public bool IsPublished { get; set; } = false;
}
