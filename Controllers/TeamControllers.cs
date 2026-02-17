using FotbollTournament.Model;
using Microsoft.AspNetCore.Mvc;
using FotbollTournament.Services.Interface;
using AutoMapper;
using FotbollTournament.DTOS;
namespace FotbollTournament.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TeamDto>>(teams);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
                return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            var created = await _teamService.CreateAsync(team);
            return CreatedAtAction(nameof(GetById), new { id = created.TeamId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Team team)
        {
            if (id != team.TeamId)
                return BadRequest();

            var updated = await _teamService.UpdateAsync(team);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _teamService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
