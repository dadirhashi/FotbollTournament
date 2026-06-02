using FotbollTournament.Domain.Entities;
using FotbollTournament.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FotbollTournament.Infrastructure.Persistence;

namespace FotbollTournament.Infrastructure.Repositories
{
    public class PlayerRepositories : IPlayerRepository
    {
        private readonly AppDB _context;

        public PlayerRepositories(AppDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
            => await _context.Players.Include(p => p.Team).ToListAsync();

        public async Task<Player?> GetByIdAsync(int id)
            => await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.PlayerId == id);
        public async Task AddAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player is null) return;
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }

    }
}
