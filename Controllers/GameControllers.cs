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

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, [FromQuery] GameDto dto)
        {
            // 1. Kontrollera att id i URL matchar id i body
            if (id != dto.GameId)
                return BadRequest("Id mismatch");

            // 2. Hämta spelet från databasen
            var existingGame = await _gameService.GetByIdAsync(id);
            if (existingGame == null)
                return NotFound();

            // 3. Mappa DTO → entity (uppdatera befintligt objekt)
            _mapper.Map(dto, existingGame);

            // 4. Uppdatera i databasen
            var updated = await _gameService.UpdateAsync(existingGame);

            if (!updated)
                return StatusCode(500, "Could not update game");

            return NoContent();
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _gameService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
