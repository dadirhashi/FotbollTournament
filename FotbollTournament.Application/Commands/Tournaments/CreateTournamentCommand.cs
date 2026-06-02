using MediatR;
using FotbollTournament.DTOS;
namespace FotbollTournament.Application.Commands.Tournaments
{
   public record CreateTournamentCommand : IRequest<TournamentDto>
    {
        public int TournamentId { get; init; }
        public string TournamentName { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
    }


    public record UpdateTournamentCommand : IRequest
    {
        public int TournamentId { get; init; }
        public string TournamentName { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
    }

    public record DeleteTournamentCommand(int TournamentId) : IRequest;
}
