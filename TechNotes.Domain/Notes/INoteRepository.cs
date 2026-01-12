
namespace TechNotes.Domain.Notes;

public interface INoteRepository
{
    Task<List<Note>> GetAllNotesAsync();
    Task<Note?> GetNoteByIdAsync(Guid id);
    Task<Note> CreateNoteAsync(Note note);
}
