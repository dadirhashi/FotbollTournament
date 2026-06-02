using FotbollTournament.Domain.Interfaces;
using MediatR;
using FotbollTournament.Application.DTOs;

namespace FotbollTournament.Application.Commands.JWT
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>, IRequestHandler<RegisterCommand, AuthResponseDto>, IRequestHandler<UpdateUserCommand, AuthResponseDto>, IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _users;
        private readonly IJwtTokenService _tokens;

        public LoginCommandHandler(IUserRepository users, IJwtTokenService tokens)
        {
            _users = users;
            _tokens = tokens;
        }

        public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken ct)
        {
            var user = await _users.GetByUsernameAsync(request.Username);
            if (user is null || user.Password != request.Password)
                throw new UnauthorizedAccessException("Invalid credentials.");

            var token = _tokens.GenerateToken(user, new[] { user.Role });
            return new AuthResponseDto(token, user.UserName, new[] { user.Role });
        }
        public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken ct)
        {
            var user = new Domain.Entities.User
            {
                UserName = request.Username,
                Password = request.Password
            };
            await _users.AddAsync(user);
            var token = _tokens.GenerateToken(user, new[] { user.Role });
            return new AuthResponseDto(token, user.UserName, new[] { user.Role });
        }

        public async Task<AuthResponseDto> Handle(UpdateUserCommand request, CancellationToken ct)
        {
            var user = await _users.GetByUsernameAsync(request.Username);
            if (user is null)
                throw new UnauthorizedAccessException("User not found.");
            user.UserName = request.Username;
            user.Password = request.Password;
            await _users.UpdateAsync(user);
            var token = _tokens.GenerateToken(user, new[] { user.Role });
            return new AuthResponseDto(token, user.UserName, new[] { user.Role });
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken ct)
        {
            await _users.DeleteAsync(request.Id);
        }
    }
}
