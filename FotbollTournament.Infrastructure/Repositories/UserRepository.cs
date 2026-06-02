using FotbollTournament.Domain.Interfaces;
using FotbollTournament.Domain.Entities;
using FotbollTournament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FotbollTournament.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDB _context;
        public UserRepository(AppDB context) => _context = context;

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null) return;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByUsernameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == name);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
