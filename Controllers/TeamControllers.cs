using FotbollTournament.Application.Commands.Games;
using FotbollTournament.Application.Commands.Teams;
using FotbollTournament.Application.Queries.Teams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace FotbollTournament.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeamController (IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAllTeamsQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int teamId)
            => Ok(await _mediator.Send(new GetTeamsByIdQuery(teamId)));
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeamCommand command)
        {
            var dto = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { teamId = dto.TeamId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGameCommand command)
        {
            await _mediator.Send(command with { Id = id });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTeamCommand(id));
            return NoContent();
        }
    
    }
}
