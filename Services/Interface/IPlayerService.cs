using FotbollTournament.Model;

namespace FotbollTournament.Services.Interface
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllAsync();
        Task<Player?> GetByIdAsync(int id);
        Task<Player> CreateAsync(Player player);
        Task<bool> UpdateAsync(Player player);
        Task<bool> DeleteAsync(int id);
    }
}
