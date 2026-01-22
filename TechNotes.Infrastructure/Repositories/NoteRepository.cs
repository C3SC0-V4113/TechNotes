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
    public async Task<Note?> UpdateNoteAsync(Note note)
    {
        var existingNote = _context.Notes.Find(note.Id);
        if (existingNote == null)
        {
            return await Task.FromResult<Note?>(null);
        }

        existingNote.Title = note.Title;
        existingNote.Content = note.Content;
        existingNote.PublishedAt = note.PublishedAt;
        existingNote.IsPublished = note.IsPublished;
        existingNote.UpdatedAt = DateTime.UtcNow;

        _context.Notes.Update(existingNote);
        await _context.SaveChangesAsync();

        return await Task.FromResult<Note?>(existingNote);
    }

    public async Task<bool> DeleteNoteAsync(int id)
    {
        var note = await GetNoteByIdAsync(id);
        if (note == null)
        {
            return await Task.FromResult(false);
        }

        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }
}
