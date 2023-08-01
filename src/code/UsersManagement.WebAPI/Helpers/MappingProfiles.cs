using AutoMapper;
using UsersManagement.Core.Entities;
using UsersManagement.WebAPI.Dtos;

namespace UsersManagement.WebAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
