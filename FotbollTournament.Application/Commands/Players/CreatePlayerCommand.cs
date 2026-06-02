using MediatR;
using FotbollTournament.Application.DTOs;

namespace FotbollTournament.Application.Commands.Players
{
    public record CreatePlayerCommand(
        string FirstName,
        string LastName,
        string Position,
        int TeamId,
        int PlayerId
        ) : IRequest<PlayerDto>;

       public record UpdatePlayerCommand(
        int Id,
        string FirstName,
        string LastName,
        string Position,
        int TeamId
        ) : IRequest;
    public record DeletePlayerCommand(int Id) : IRequest;

}
