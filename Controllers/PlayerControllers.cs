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

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string ? Name)
        {
            var players = await _playerService.GetAllAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            var created = await _playerService.CreateAsync(player);
            return CreatedAtAction(nameof(GetById), new { id = created.PlayerId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Player player)
        {
            if (id != player.PlayerId)
                return BadRequest();

            var updated = await _playerService.UpdateAsync(player);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _playerService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
