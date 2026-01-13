
namespace TechNotes.Domain.Notes;

public interface INoteRepository
{
    Task<List<Note>> GetAllNotesAsync();
    Task<Note?> GetNoteByIdAsync(int id);
    Task<Note> CreateNoteAsync(Note note);
    Task<Note?> UpdateNoteAsync(Note note);
}
