
namespace TechNotes.Domain.Notes;

public interface INoteRepository
{
    Task<List<Note>> GetAllNotesAsync();
}
