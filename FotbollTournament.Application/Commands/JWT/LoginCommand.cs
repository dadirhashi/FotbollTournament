using MediatR;
using FotbollTournament.Application.DTOs;

namespace FotbollTournament.Application.Commands.JWT
{
    public record LoginCommand(string Username, string Password) : IRequest<AuthResponseDto>;

    public record RegisterCommand(string Username, string Password) : IRequest<AuthResponseDto>;
    public record UpdateUserCommand(int Id, string Username, string Password) : IRequest<AuthResponseDto>;
    public record DeleteUserCommand(int Id) : IRequest;


}
