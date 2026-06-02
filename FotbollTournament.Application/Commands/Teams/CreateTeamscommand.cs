using MediatR;
using FotbollTournament.DTOS;


namespace FotbollTournament.Application.Commands.Teams
{
   public record CreateTeamCommand(
       int TeamId,
       string TeamName,
       string CoachName,
       int TournamentId
       ) : IRequest<TeamDto>;

    public record UppadeteTeamCommand(
        int TeamId,
       string TeamName,
       string CoachName,
       int TournamentId

        ) : IRequest;

    public record DeleteTeamCommand(int TeamId) : IRequest;


}
