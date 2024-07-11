using System.Security.Principal;
using AutoMapper;
using System.Linq;
using WebApi.Entities.DataTransferObjects;
using WebApi.Entities.Models;

namespace WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserForCreateDto, User>();
        }
    }
}