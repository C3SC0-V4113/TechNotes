namespace TechNotes.Application.Notes;

public record struct NoteResponse(
    int Id,
    string Title,
    string? Content,
    DateTime PublishedAt,
    bool IsPublished
);