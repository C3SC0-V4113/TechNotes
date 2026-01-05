using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes;

public class NotesService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NotesService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<List<Note>> GetAllNotesAsync()
    {
        return await _noteRepository.GetAllNotesAsync();
    }
}
