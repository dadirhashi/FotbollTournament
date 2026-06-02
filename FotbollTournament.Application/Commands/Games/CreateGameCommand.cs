using FotbollTournament.Application.DTOs;
using MediatR;

namespace FotbollTournament.Application.Commands.Games;

public record CreateGameCommand(
    DateTime KickOff,
    int HomeTeamId,
    int AwayTeamId,
    int TournamentId
) : IRequest<GameDto>;

public record UpdateGameCommand(
    int Id,
    DateTime KickOff,
    int HomeTeamId,
    int AwayTeamId,
    int TournamentId
) : IRequest;

public record DeleteGameCommand(int Id) : IRequest;
