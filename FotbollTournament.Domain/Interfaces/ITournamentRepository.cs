using FotbollTournament.Domain.Entities;
 

namespace FotbollTournament.Domain.Interfaces
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetAllAsync();
        Task<Tournament?> GetByIdAsync(int id);
        Task AddAsync(Tournament tournament);
        Task UpdateAsync(Tournament tournament);
        Task DeleteAsync(int id);
    }
}
