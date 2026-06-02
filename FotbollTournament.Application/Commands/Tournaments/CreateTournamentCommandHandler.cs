using AutoMapper;
using FotbollTournament.Domain.Interfaces;
using FotbollTournament.DTOS;


namespace FotbollTournament.Application.Commands.Tournaments
{
    public class CreateTournamentCommandHandler
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;
        public CreateTournamentCommandHandler(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public async Task<TournamentDto> Handle(CreateTournamentCommand request, CancellationToken ct)
        {
            var tournament = new Domain.Entities.Tournament
            {
                TournamentId = request.TournamentId,
                Name = request.TournamentName,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
            await _tournamentRepository.AddAsync(tournament);
            return _mapper.Map<TournamentDto>(tournament);
        }

        public async Task Handle(UpdateTournamentCommand request, CancellationToken ct)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(request.TournamentId);
            if (tournament is null) return;
            tournament.Name = request.TournamentName;
            tournament.StartDate = request.StartDate;
            tournament.EndDate = request.EndDate;
            await _tournamentRepository.UpdateAsync(tournament);
        }

        public async Task Handle(DeleteTournamentCommand request, CancellationToken ct)
        {
            await _tournamentRepository.DeleteAsync(request.TournamentId);
        }
    }
}
