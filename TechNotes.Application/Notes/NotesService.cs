using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes;

public class NotesService : INoteService
{
    public List<Note> GetAllNotes()
    {
        return new List<Note>
        {
            new()
            {
                Id = 1,
                Title = "First Note",
                Content = "This is the content of the first note.",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                PublishedAt = DateTime.UtcNow.AddDays(-1),
                IsPublished = true
            },
            new()
            {
                Id = 2,
                Title = "Second Note",
                Content = "This is the content of the second note.",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                PublishedAt = null,
                IsPublished = false
            }
        };
    }
}
