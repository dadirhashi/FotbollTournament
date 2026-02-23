using AutoMapper;
using FotbollTournament.DTOS;
using FotbollTournament.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Tournament, TournamentDto>();
        CreateMap<Team, TeamDto>();
        CreateMap<Player, PlayerDto>().ReverseMap();
        CreateMap<Game, GameDto>()
            .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.TeamName))
            .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.TeamName));

        CreateMap<GameDto, Game>();
    }
}