using FotbollTournament.Domain.Entities;

namespace FotbollTournament.Domain.Interfaces
{

    public interface IJwtTokenService
    {
        string GenerateToken(User user, IEnumerable<string> roles);
    }
}
