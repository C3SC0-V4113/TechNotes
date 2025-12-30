using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes;

public interface INoteService
{
    List<Note> GetAllNotes();
}
