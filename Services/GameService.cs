using AutoMapper;
using FotbollTournament.DB;
using FotbollTournament.DTOS;
using FotbollTournament.Model;
using FotbollTournament.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
            var updateGame = await _context.Games.FindAsync(game.GameId);
            if (updateGame == null) 
                return false;
            await _context.SaveChangesAsync();
            return true;

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
