using AutoMapper;
using FotbollTournament.DTOS;
using FotbollTournament.Model;
using FotbollTournament.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace FotbollTournament.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        // GET: api/player
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerService.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<PlayerDto>>(players);
            return Ok(dto);
        }

        // GET: api/player/5
        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null)
                return NotFound();

            var dto = _mapper.Map<PlayerDto>(player);
            return Ok(dto);
        }

        // POST: api/player
        [HttpPost]
        public async Task<IActionResult> Create(PlayerDto playerDto)
        {
            var player = _mapper.Map<PlayerDto, Player>(playerDto);
            var created = await _playerService.CreateAsync(player);

            var dto = _mapper.Map<PlayerDto>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.PlayerId }, dto);
        }

        // PUT: api/player/5
        [HttpPut("id")]
        public async Task<IActionResult> Update([FromQuery]int id, PlayerDto dto)
        {
            if (id != dto.PlayerId)
                return BadRequest("Id mismatch");

            var existingPlayer = await _playerService.GetByIdAsync(id);
            if (existingPlayer == null)
                return NotFound();

            _mapper.Map(dto, existingPlayer);

            var updated = await _playerService.UpdateAsync(existingPlayer);
            if (!updated)
                return StatusCode(500, "Could not update player");

            return NoContent();
        }

        // DELETE: api/player/5
        [HttpDelete("id")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var deleted = await _playerService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
