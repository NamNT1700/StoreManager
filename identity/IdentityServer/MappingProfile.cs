using AutoMapper;
using Base.Models;
using Server.Identity.DTO;

namespace Server.Identity
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}