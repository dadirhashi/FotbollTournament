using FotbollTournament.Domain.Entities;
using FotbollTournament.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FotbollTournament.Infrastructure.Persistence;

namespace FotbollTournament.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDB _context;

    public GameRepository(AppDB context) => _context = context;

    public async Task<IEnumerable<Game>> GetAllAsync()
        => await _context.Games.Include(g => g.HomeTeam).Include(g => g.AwayTeam).ToListAsync();

    public async Task<Game?> GetByIdAsync(int id)
        => await _context.Games.Include(g => g.HomeTeam).Include(g => g.AwayTeam)
            .FirstOrDefaultAsync(g => g.GameId == id);

    public async Task AddAsync(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game game)
    {
        _context.Games.Update(game);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game is not null)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}