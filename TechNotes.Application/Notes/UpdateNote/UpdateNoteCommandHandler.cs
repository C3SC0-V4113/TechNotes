using Mapster;
using TechNotes.Application.Abstractions.RequestHandling;
using TechNotes.Domain.Abstractions;
using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes.UpdateNote;

public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand, NoteResponse?>
{
    private readonly INoteRepository _noteRepository;

    public UpdateNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<Result<NoteResponse?>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var existingNote = request.Adapt<Note>();
        var updatedNote = await _noteRepository.UpdateNoteAsync(existingNote);
        if (updatedNote == null)
        {
            return Result.Fail<NoteResponse?>("Note not found or could not be updated.");
        }
        return updatedNote.Adapt<NoteResponse>();
    }
}
