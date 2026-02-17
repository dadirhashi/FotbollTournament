using FotbollTournament.DB;
using FotbollTournament.Model;
using FotbollTournament.Services.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace FotbollTournament.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
   

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var games = await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .Include(g => g.Tournament)
                .ToListAsync();
            return games;
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            var creategame = await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .Include(g => g.Tournament)
                .FirstOrDefaultAsync(g => g.GameId == id);
            return creategame;
        }

        public async Task<Game> CreateAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return false;

            _context.Games.Remove(game);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
