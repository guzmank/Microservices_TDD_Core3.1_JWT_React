using AutoMapper;
using Home.Framework.Dtos;
using Home.WebApi.Models;

namespace Home.WebApi.Mappers
{
    public class ControllerAutoMapperProfile : Profile
    {
        public ControllerAutoMapperProfile()
        {
            // REMOVE MORE AHEAD... THIS IS AN EXAMPLE... 

            CreateMap<AlbumDto, AlbumViewModel>();
            CreateMap<AlbumViewModel, AlbumDto>();

            //CreateMap<Framework.Data.Entities.AlbumEntity, AlbumDto>();
            //CreateMap<AlbumDto, Framework.Data.Entities.AlbumEntity>();

            CreateMap<AlbumPriceDto, AlbumPriceViewModel>();
            CreateMap<AlbumPriceViewModel, AlbumPriceDto>();

            CreateMap<AlbumRatingDto, AlbumRatingViewModel>();
            CreateMap<AlbumRatingViewModel, AlbumRatingDto>();

            CreateMap<ArtistDto, ArtistViewModel>();
            CreateMap<ArtistViewModel, ArtistDto>();

            CreateMap<ContactsDto, ContactsViewModel>();
            CreateMap<ContactsViewModel, ContactsDto>();

            CreateMap<MusicTypeDto, MusicTypeViewModel>();
            CreateMap<MusicTypeViewModel, MusicTypeDto>();

            CreateMap<RatingTypeDto, RatingTypeViewModel>();
            CreateMap<RatingTypeViewModel, RatingTypeDto>();

            CreateMap<SongDto, SongViewModel>();
            CreateMap<SongViewModel, SongDto>();

            CreateMap<SongPriceDto, SongPriceViewModel>();
            CreateMap<SongPriceViewModel, SongPriceDto>();

            // ORIGINAL CODE
            CreateMap<CompanyDto, CompanyViewModel>();
            CreateMap<CompanyViewModel, CompanyDto>();

            CreateMap<DepartmentDto, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, DepartmentDto>();

            CreateMap<DepartmentEmployeeDto, DepartmentEmployeeViewModel>();
            CreateMap<DepartmentEmployeeViewModel, DepartmentEmployeeDto>();

            CreateMap<EmployeeDto, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, EmployeeDto>();

            CreateMap<GenderDto, GenderViewModel>();
            CreateMap<GenderViewModel, GenderDto>();

            CreateMap<LanguageDto, LanguageViewModel>();
            CreateMap<LanguageViewModel, LanguageDto>();

            CreateMap<RoleDto, RoleViewModel>();
            CreateMap<RoleViewModel, RoleDto>();

            CreateMap<SiteStyleTypeDto, SiteStyleTypeViewModel>();
            CreateMap<SiteStyleTypeViewModel, SiteStyleTypeDto>();

            CreateMap<SystemTypeDto, SystemTypeViewModel>();
            CreateMap<SystemTypeViewModel, SystemTypeDto>();

            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>();

            CreateMap<UserRoleDto, UserRoleViewModel>();
            CreateMap<UserRoleViewModel, UserRoleDto>();

            CreateMap<VersionHistoryDto, VersionHistoryViewModel>();
            CreateMap<VersionHistoryViewModel, VersionHistoryDto>();
        }
    }
}
