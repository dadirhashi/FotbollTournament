using FotbollTournament.DTOS;
using MediatR;

namespace FotbollTournament.Application.Queries.Tornament
{
    public record GetAllTournamentsQuery : IRequest<IEnumerable<TournamentDto>>;
    public record GetTournamentByIdQuery(int Id) : IRequest<TournamentDto?>;
}
