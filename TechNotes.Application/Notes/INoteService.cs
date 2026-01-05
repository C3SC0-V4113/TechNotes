using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes;

public interface INoteService
{
    Task<List<Note>> GetAllNotesAsync();
}
