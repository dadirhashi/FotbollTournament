using AutoMapper;
using FotbollTournament.Domain.Interfaces;
using FotbollTournament.DTOS;

namespace FotbollTournament.Application.Queries.Tornament
{
    public class GetAllTournamentQueryHandler
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;   
        public GetAllTournamentQueryHandler(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TournamentDto>> Handle(GetAllTournamentsQuery request, CancellationToken ct)
        {
            var tournament = await _tournamentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TournamentDto>>(tournament);
        }

        public async Task<TournamentDto?> Handle(GetTournamentByIdQuery request, CancellationToken ct)
            {
                var tournament = await _tournamentRepository.GetByIdAsync(request.Id);
                return tournament is not null ? _mapper.Map<TournamentDto>(tournament) : null;
        }
    }
}
