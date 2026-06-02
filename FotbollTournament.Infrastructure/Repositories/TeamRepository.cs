using FotbollTournament.Domain.Interfaces;
using FotbollTournament.Domain.Entities;
using FotbollTournament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace FotbollTournament.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDB _context;
        public TeamRepository(AppDB context) => _context = context;
        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams;

        }

        public async Task<Team?> GetByIdAsync(int id) =>
            await _context.Teams.FirstOrDefaultAsync(t => t.TeamId == id);


        public async Task AddAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
         
        }
    }
}
