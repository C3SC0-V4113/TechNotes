using MediatR;

namespace TechNotes.Application.Notes.UpdateNote;

public class UpdateNoteCommand : IRequest<NoteResponse?>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    public bool IsPublished { get; set; } = false;
}