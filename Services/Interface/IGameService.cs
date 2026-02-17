using FotbollTournament.Model;

namespace FotbollTournament.Services.Interface
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetByIdAsync(int id);
        Task<Game> CreateAsync(Game game);
        Task<bool> UpdateAsync(Game game);
        Task<bool> DeleteAsync(int id);
    }
}
