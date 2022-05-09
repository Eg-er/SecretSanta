using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SecretSanta.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task CreateAsync(User u);

        Task SaveChangesAsync();
    }
}