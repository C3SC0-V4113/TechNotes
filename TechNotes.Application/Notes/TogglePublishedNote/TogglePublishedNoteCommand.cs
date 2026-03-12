namespace TechNotes.Application.Notes.TogglePublishedNote;

public class TogglePublishedNoteCommand : ICommand<NoteResponse>
{
    public int NoteId { get; set; }
}
