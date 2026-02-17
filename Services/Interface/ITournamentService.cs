using FotbollTournament.Model;

namespace FotbollTournament.Services.Interface
{
    public interface ITournamentService
    {
        Task<IEnumerable<Tournament>> GetAllAsync();
        Task<Tournament?> GetByIdAsync(int id);
        Task<Tournament> CreateAsync(Tournament tournament);
        Task<bool> UpdateAsync(Tournament tournament);
        Task<bool> DeleteAsync(int id);
    }
}
