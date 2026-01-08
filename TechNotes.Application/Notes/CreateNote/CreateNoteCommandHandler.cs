using Mapster;
using MediatR;
using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, NoteResponse>
{
    private readonly INoteRepository _noteRepository;

    public CreateNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<NoteResponse> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var newNote = request.Adapt<Note>();
        var createdNote = await _noteRepository.CreateNoteAsync(newNote);
        return createdNote.Adapt<NoteResponse>();
    }
}