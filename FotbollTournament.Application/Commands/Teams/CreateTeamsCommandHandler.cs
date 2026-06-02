using AutoMapper;
using FotbollTournament.Domain.Entities;
using FotbollTournament.Domain.Interfaces;
using MediatR;
using FotbollTournament.DTOS;


namespace FotbollTournament.Application.Commands.Teams
{
    public class CreateTeamsCommandHandler : IRequestHandler<CreateTeamCommand, TeamDto>, IRequestHandler<UppadeteTeamCommand>, IRequestHandler<DeleteTeamCommand>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        public CreateTeamsCommandHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken ct)
        {
            var team = new Team
            {
                TeamId = request.TeamId,
                TeamName = request.TeamName,
                CoachName = request.CoachName,
                TournamentId = request.TournamentId
            };
            
            await _teamRepository.AddAsync(team);
            return _mapper.Map<TeamDto>(team);
        }

        public async Task Handle(UppadeteTeamCommand request, CancellationToken ct)
        {
            var team = await _teamRepository.GetByIdAsync(request.TeamId);
            if (team is null) return;
            team.TeamName = request.TeamName;
            team.CoachName = request.CoachName;
            team.TournamentId = request.TournamentId;
            await _teamRepository.UpdateAsync(team);
        }

        public async Task Handle(DeleteTeamCommand request, CancellationToken ct)
        {
            await _teamRepository.DeleteAsync(request.TeamId);
        }
    }
}
