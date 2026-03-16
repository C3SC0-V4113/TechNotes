using Microsoft.AspNetCore.Mvc;
using TechNotes.Application.Abstractions.RequestHandling;
using TechNotes.Application.Notes;
using TechNotes.Application.Notes.GetNotesByCurrentUser;
using TechNotes.Application.Notes.TogglePublishedNote;

namespace TechNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ISender _sender;
        public NotesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteResponse>>> GetNotesByCurrentUser()
        {
            var result = await _sender.Send(new GetNotesByCurrentUserQuery());
            if (result.HasFailed)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Value);
        }
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<NoteResponse>> TogglePublishedNote(int id)
        {
            var command = new TogglePublishedNoteCommand
            {
                NoteId = id
            };
            var result = await _sender.Send(command);
            if (result.HasFailed)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Value);
        }
    }
}
