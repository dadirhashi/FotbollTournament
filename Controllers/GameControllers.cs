using FotbollTournament.Model;
using Microsoft.AspNetCore.Mvc;
using FotbollTournament.Services.Interface;
using FotbollTournament.DTOS;
using AutoMapper;
namespace FotbollTournament.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<GameDto>>(games);
            return Ok(dto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
                return NotFound();

            var dto = _mapper.Map<GameDto> (game);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameDto gamedto)
        {
            var game = _mapper.Map<GameDto, Game>(gamedto);
            var created = await _gameService.CreateAsync(game);
            var dto = _mapper.Map<GameDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.GameId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Game game)
        {
            if (id != game.GameId)
                return BadRequest();

            var updated = await _gameService.UpdateAsync(game);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _gameService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
