using FotbollTournament.Application.Commands.Games;
using FotbollTournament.Application.Queries.Games;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FotbollTournament.Application.Commands.Games;

namespace FotbollTournament.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IMediator _mediator;
    public GamesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllGamesQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetGameByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGameCommand command)
    {
        var dto = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = dto.GameId }, dto);
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
        await _mediator.Send(new DeleteGameCommand(id));
        return NoContent();
    }
}
