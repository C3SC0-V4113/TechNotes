using Microsoft.EntityFrameworkCore;
using TechNotes.Domain.Notes;

namespace TechNotes.Infrastructure.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly ApplicationDbContext _context;

    public NoteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Note>> GetAllNotesAsync()
    {
        return await _context.Notes.ToListAsync();
    }
    public async Task<Note> CreateNoteAsync(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
        return await Task.FromResult(note);
    }
    public async Task<Note?> GetNoteByIdAsync(int id)
    {
        return await _context.Notes.FindAsync(id);
    }
}
