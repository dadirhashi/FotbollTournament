using MediatR;
using FotbollTournament.Application.DTOs;
using FotbollTournament.Domain.Entities;
using AutoMapper;
using FotbollTournament.Domain.Interfaces;
namespace FotbollTournament.Application.Commands.Players
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, PlayerDto>, IRequestHandler<UpdatePlayerCommand>, IRequestHandler<DeletePlayerCommand>
    {
        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;
        public CreatePlayerCommandHandler(IPlayerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PlayerDto> Handle(CreatePlayerCommand request, CancellationToken ct)
        {
            var player = new Player
            {
                FirstName = request.FirstName,
                Position = request.Position,
                TeamId = request.TeamId
            };
            await _repository.AddAsync(player);
            return _mapper.Map<PlayerDto>(player);
        }

        public async Task Handle(UpdatePlayerCommand request, CancellationToken ct)
        {
            var player = await _repository.GetByIdAsync(request.Id);
            if (player is null) return;
            player.FirstName = request.FirstName;
            player.Position = request.Position;
            player.TeamId = request.TeamId;
            await _repository.UpdateAsync(player);
        }

        public async Task Handle(DeletePlayerCommand request, CancellationToken ct)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
