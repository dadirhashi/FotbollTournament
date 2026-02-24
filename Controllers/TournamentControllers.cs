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

            var dto = _mapper.Map<TournamentDto>(tournament);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TournamentDto tournamentDto)
        {
            var tournament = _mapper.Map<TournamentDto, Tournament>(tournamentDto);
            var created = await _tournamentService.CreateAsync(tournament);
            var dto = _mapper.Map<TournamentDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.TournamentId }, created);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, TournamentDto tournamentDto)
        {
            if (id != tournamentDto.TournamentId)
                return BadRequest("Id not found");
            var exsistingTournament = await _tournamentService.GetByIdAsync(id);
           _mapper.Map(tournamentDto, exsistingTournament);

            var updated = await _tournamentService.UpdateAsync(exsistingTournament);
            if (!updated)
                return NotFound("Tournament not found");

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tournamentService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }


}

