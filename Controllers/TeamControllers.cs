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

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
                return NotFound();
            var dto = _mapper.Map<TeamDto>(team);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamDto teamDto)
        {
            var team = _mapper.Map<TeamDto, Team>(teamDto);
            var created = await _teamService.CreateAsync(team);
            var dto = _mapper.Map<TeamDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.TeamId }, created);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update([FromQuery] int id, TeamDto teamDto)
        {
            if (id != teamDto.TeamId)
                return BadRequest("Team could not be found");

            var existing = await _teamService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _mapper.Map(teamDto, existing);

            var updated = await _teamService.UpdateAsync(existing);
            if (!updated)
                return StatusCode(500, "Could not update team");

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            var deleted = await _teamService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            else
                Console.WriteLine("Team deleted");

            return NoContent();
        }
    }
}
