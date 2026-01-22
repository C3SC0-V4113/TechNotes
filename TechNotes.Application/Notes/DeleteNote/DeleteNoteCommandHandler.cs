using MediatR;
using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, bool>
{
    private readonly INoteRepository _noteRepository;

    public DeleteNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<bool> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _noteRepository.DeleteNoteAsync(request.Id);
        return deleted;
    }
}