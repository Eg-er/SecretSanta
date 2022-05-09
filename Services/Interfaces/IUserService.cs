using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SecretSanta.Models;

namespace SecretSanta.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task CreateAsync(UserDTO u);
        Task ShuffleUsersAsync();
    }
}