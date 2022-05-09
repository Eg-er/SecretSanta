using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SecretSanta.Models;
using SecretSanta.Models.Interfaces;
using SecretSanta.Services.Interfaces;

namespace SecretSanta.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task CreateAsync(UserDTO u)
        {
            await _repository.CreateAsync(_mapper.Map<User>(u));
            await ShuffleUsersAsync();
        }
        


        public async Task ShuffleUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            if (users.Count() == 1)
            {
                
                var user = users.FirstOrDefault();
                user.ReceiverId = user.Id;
                await _repository.SaveChangesAsync();
            }
            else
            {
                var ids = users.Select(e => e.Id).ToList();
                Random random = new();
                foreach (var user in users)
                {
                    var receiverId = user.Id;
                    while (receiverId == user.Id)
                    {
                        int number = random.Next(0, ids.Count);
                        receiverId = ids[number];
                    }
                    ids.Remove(receiverId);
                    user.ReceiverId = receiverId;
                    await _repository.SaveChangesAsync();
                }

                if (users.Any(e => e.ReceiverId == null))
                    await ShuffleUsersAsync();
            }
        }
    }
}