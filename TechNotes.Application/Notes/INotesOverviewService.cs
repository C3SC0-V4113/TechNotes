namespace TechNotes.Application.Notes;

public interface INotesOverviewService
{
    Task<NoteResponse?> TogglePublishedNoteAsync(int NoteId);
    Task<List<NoteResponse>?> GetNotesByCurrentUserAsync();
}
