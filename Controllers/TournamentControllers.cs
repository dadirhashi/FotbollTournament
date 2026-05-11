using FotbollTournament.Application.Commands.Tournaments;
using FotbollTournament.Application.Queries.Tornament;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace FotbollTournament.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TournamentController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAllTournamentsQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _mediator.Send(new GetTournamentByIdQuery(id)));    

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTournamentCommand command)
        {
            var dto = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = dto.TournamentId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTournamentCommand command)
        {
            await _mediator.Send(command with { TournamentId = id });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTournamentCommand(id));
            return NoContent();
        }

    }
}

