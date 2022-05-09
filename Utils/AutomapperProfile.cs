using AutoMapper;
using SecretSanta.Models;
using SecretSanta.Services;

namespace SecretSanta.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}