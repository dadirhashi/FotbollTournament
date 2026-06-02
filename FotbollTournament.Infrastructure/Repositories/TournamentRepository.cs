using FotbollTournament.Domain.Entities;
using FotbollTournament.Domain.Interfaces;
using FotbollTournament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace FotbollTournament.Infrastructure.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly AppDB _context;

        public TournamentRepository (AppDB context) => _context = context;

        public async Task<IEnumerable<Tournament>> GetAllAsync()
            => await _context.Tournaments.Include(t => t.Teams).ToListAsync();

        public async Task<Tournament?> GetByIdAsync(int id)
            => await _context.Tournaments.Include(t => t.Teams)
                .FirstOrDefaultAsync(t => t.TournamentId == id);

        public async Task AddAsync(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament is not null)
            {
                _context.Tournaments.Remove(tournament);
                await _context.SaveChangesAsync();
            }
        }
    }
}
