using AutoMapper;
using FotbollTournament.Application.DTOs;
using FotbollTournament.Domain.Entities;
using FotbollTournament.DTOS;
namespace FotbollTournament.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Game, GameDto>()
            .ForMember(d => d.HomeTeamName, opt => opt.MapFrom(s => s.HomeTeam.TeamName))
            .ForMember(d => d.AwayTeamName, opt => opt.MapFrom(s => s.AwayTeam.TeamName));

        CreateMap<Player, PlayerDto>();
        CreateMap<Team, TeamDto>();
        CreateMap<Tournament, TournamentDto>();
    }
}