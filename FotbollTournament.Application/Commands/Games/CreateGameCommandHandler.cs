using AutoMapper;
using FotbollTournament.Application.DTOs;
using FotbollTournament.Domain.Entities;
using FotbollTournament.Domain.Interfaces;
using MediatR;

namespace FotbollTournament.Application.Commands.Games;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameDto>, IRequestHandler<UpdateGameCommand>, IRequestHandler<DeleteGameCommand> 
{
    private readonly IGameRepository _repository;
    private readonly IMapper _mapper;

    public CreateGameCommandHandler(IGameRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GameDto> Handle(CreateGameCommand request, CancellationToken ct)
    {
        var game = new Game
        {
            KickOff = request.KickOff,
            HomeTeamId = request.HomeTeamId,
            AwayTeamId = request.AwayTeamId,
            TournamentId = request.TournamentId
        };

        await _repository.AddAsync(game);
        return _mapper.Map<GameDto>(game);
    }

    public async Task Handle(UpdateGameCommand request, CancellationToken ct)
    {
        var game = await _repository.GetByIdAsync(request.Id);
        if (game is null) return;
        game.KickOff = request.KickOff;
        game.HomeTeamId = request.HomeTeamId;
        game.AwayTeamId = request.AwayTeamId;
        game.TournamentId = request.TournamentId;
        await _repository.UpdateAsync(game);
    }

    public async Task Handle(DeleteGameCommand request, CancellationToken ct)
    {
      await _repository.DeleteAsync(request.Id);
    }
}