using FotbollTournament.DB;
using FotbollTournament.Model;
using FotbollTournament.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FotbollTournament.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _context.Tournaments
                .Include(t => t.Teams)
                .Include(t => t.Games)
                .ToListAsync();
        }

        public async Task<Tournament?> GetByIdAsync(int id)
        {
            return await _context.Tournaments
                .Include(t => t.Teams)
                .Include(t => t.Games)
                .FirstOrDefaultAsync(t => t.TournamentId == id);
        }

        public async Task<Tournament> CreateAsync(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task<bool> UpdateAsync(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
                return false;

            _context.Tournaments.Remove(tournament);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
