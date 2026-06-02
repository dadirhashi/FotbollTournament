using MediatR;
using FotbollTournament.Application.DTOs;

namespace FotbollTournament.Application.Queries.Players
{
    public record GetAllPlayersQuery : IRequest<IEnumerable<PlayerDto>>;
    public record GetPlayerByIdQuery(int Id) : IRequest<PlayerDto?>;
}
