using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Models.Interfaces;
using SecretSanta.Services;

namespace SecretSanta.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly SecretSantaDbContext _context;
        public UserRepository(SecretSantaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(User u)
        {
            await _context.AddAsync(u);
            await _context.SaveChangesAsync();
        }
    }
}