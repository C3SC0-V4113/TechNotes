using TechNotes.Application.Abstractions.RequestHandling;

namespace TechNotes.Application.Notes.DeleteNote;

public class DeleteNoteCommand : ICommand
{
    public int Id { get; set; }
}
