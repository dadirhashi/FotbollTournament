using FotbollTournament.Model;
using Microsoft.AspNetCore.Mvc;
using FotbollTournament.Services.Interface;
using FotbollTournament.DTOS;
using AutoMapper;
namespace FotbollTournament.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentService tournamentService, IMapper mapper)
        {
            _tournamentService = tournamentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string ? Name)
        {
            var tournaments = await _tournamentService.GetAllAsync();
            var dto = _mapper.Map<List<Tournament>, List<TournamentDto>>(tournaments.ToList());
            return Ok(dto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var tournament = await _tournamentService.GetByIdAsync(id);
            if (tournament == null)
                return NotFound();

            return Ok(tournament);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tournament tournament)
        {
            var created = await _tournamentService.CreateAsync(tournament);
            return CreatedAtAction(nameof(GetById), new { id = created.TournamentId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tournament tournament)
        {
            if (id != tournament.TournamentId)
                return BadRequest();

            var updated = await _tournamentService.UpdateAsync(tournament);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tournamentService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }


}

