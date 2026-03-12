using MediatR;
using TechNotes.Application.Notes.GetNotesByCurrentUser;
using TechNotes.Application.Notes.TogglePublishedNote;

namespace TechNotes.Application.Notes;

public class NotesOverviewService : INotesOverviewService
{
    private readonly ISender _sender;
    public NotesOverviewService(ISender sender)
    {
        _sender = sender;
    }
    public async Task<List<NoteResponse>?> GetNotesByCurrentUserAsync()
    {
        var result = await _sender.Send(new GetNotesByCurrentUserQuery());
        return result;
    }

    public async Task<NoteResponse?> TogglePublishedNoteAsync(int NoteId)
    {
        var result = await _sender.Send(new TogglePublishedNoteCommand
        {
            NoteId = NoteId
        });
        return result;
    }
}
