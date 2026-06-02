using AutoMapper;
using FotbollTournament.Domain.Interfaces;
using FotbollTournament.DTOS;
using MediatR;

namespace FotbollTournament.Application.Queries.Teams
{
    public class GetTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, IEnumerable<TeamDto>>, IRequestHandler<GetTeamByIdQuery, TeamDto?>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public GetTeamsQueryHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        public async Task<TeamDto?> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.Id);
            return team is not null ? _mapper.Map<TeamDto>(team) : null;
        }
    }
}
