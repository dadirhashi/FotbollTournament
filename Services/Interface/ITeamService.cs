using FotbollTournament.Model;

namespace FotbollTournament.Services.Interface
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team?> GetByIdAsync(int id);
        Task<Team> CreateAsync(Team team);
        Task<bool> UpdateAsync(Team team);
        Task<bool> DeleteAsync(int id);
    }
}
