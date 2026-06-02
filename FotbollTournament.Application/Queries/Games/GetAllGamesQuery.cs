using FotbollTournament.Application.DTOs;
using MediatR;

namespace FotbollTournament.Application.Queries.Games;

public record GetAllGamesQuery() : IRequest<IEnumerable<GameDto>>;
public record GetGameByIdQuery(int Id) : IRequest<GameDto?>;