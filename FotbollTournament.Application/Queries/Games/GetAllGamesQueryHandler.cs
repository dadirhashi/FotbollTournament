using AutoMapper;
using FotbollTournament.Application.DTOs;
using FotbollTournament.Domain.Interfaces;
using FotbollTournament.DTOS;
using MediatR;

namespace FotbollTournament.Application.Queries.Games;

public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, IEnumerable<GameDto>>, IRequestHandler<GetGameByIdQuery, GameDto?>
{
    private readonly IGameRepository _repository;
    private readonly IMapper _mapper;

    public GetAllGamesQueryHandler(IGameRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GameDto>> Handle(GetAllGamesQuery request, CancellationToken ct)
    {
        var games = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<GameDto>>(games);
    }

    public async Task<GameDto?> Handle(GetGameByIdQuery request, CancellationToken ct)
    {
        var game = await _repository.GetByIdAsync(request.Id);
        return game is not null ? _mapper.Map<GameDto>(game) : null;
    }
}