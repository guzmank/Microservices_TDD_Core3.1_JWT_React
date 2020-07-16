using AutoMapper;
using Home.Framework.Dtos;
using Home.Identity.WebApi.Models;

namespace Home.Identity.WebApi.Mappers
{
    public class ControllerAutoMapperProfile : Profile
    {
        public ControllerAutoMapperProfile()
        {
            CreateMap<RoleDto, RoleViewModel>();
            CreateMap<RoleViewModel, RoleDto>();

            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>();

            CreateMap<UserRoleDto, UserRoleViewModel>();
            CreateMap<UserRoleViewModel, UserRoleDto>();
        }
    }
}
