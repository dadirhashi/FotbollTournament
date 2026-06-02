using FotbollTournament.Application.DTOs;
using MediatR;
using FotbollTournament.Domain.Interfaces;
using AutoMapper;


namespace FotbollTournament.Application.Queries.Players
{
    public class GetPlayerQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<PlayerDto>>, IRequestHandler<GetPlayerByIdQuery, PlayerDto?>
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;

        public GetPlayerQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<PlayerDto>> Handle(GetAllPlayersQuery request, CancellationToken ct)
        {
            var player = await _playerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlayerDto>>(player);
        }

        public async Task<PlayerDto?> Handle(GetPlayerByIdQuery request, CancellationToken ct)
        {
            var player = await _playerRepository.GetByIdAsync(request.Id);
            return player is not null ? _mapper.Map<PlayerDto>(player) : null;

        }
    }
} 