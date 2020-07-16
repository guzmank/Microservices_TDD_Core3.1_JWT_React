using AutoMapper;
using Home.Framework.Data.Entities;
using Home.Framework.Dtos;
using System.Collections.Generic;

namespace Home.Framework.Mappers
{
    public class ServiceAutoMapperProfile : Profile
    {
        public ServiceAutoMapperProfile()
        {
            // REMOVE MORE AHEAD... THIS IS AN EXAMPLE... 
            CreateMap<AlbumEntity, AlbumDto>();
            CreateMap<AlbumDto, AlbumEntity>();

            CreateMap<AlbumPriceEntity, AlbumPriceDto>();
            CreateMap<AlbumPriceDto, AlbumPriceEntity>();

            CreateMap<AlbumRatingEntity, AlbumRatingDto>();
            CreateMap<AlbumRatingDto, AlbumRatingEntity>();

            CreateMap<ArtistEntity, ArtistDto>();
            CreateMap<ArtistDto, ArtistEntity>();

            CreateMap<ContactsEntity, ContactsDto>();
            CreateMap<ContactsDto, ContactsEntity>();

            CreateMap<MusicTypeEntity, MusicTypeDto>();
            CreateMap<MusicTypeDto, MusicTypeEntity>();

            CreateMap<RatingTypeEntity, RatingTypeDto>();
            CreateMap<RatingTypeDto, RatingTypeEntity>();

            CreateMap<SongEntity, SongDto>();
            CreateMap<SongDto, SongEntity>();

            CreateMap<SongPriceEntity, SongPriceDto>();
            CreateMap<SongPriceDto, SongPriceEntity>();


            // ORIGINAL CODE
            CreateMap<CompanyEntity, CompanyDto>();
            CreateMap<CompanyDto, CompanyEntity>();

            CreateMap<DepartmentEntity, DepartmentDto>();
            CreateMap<DepartmentDto, DepartmentEntity>();

            CreateMap<DepartmentEmployeeEntity, DepartmentEmployeeDto>();
            CreateMap<DepartmentEmployeeDto, DepartmentEmployeeEntity>();

            CreateMap<EmployeeEntity, EmployeeDto>();
            CreateMap<EmployeeDto, EmployeeEntity>();

            CreateMap<GenderEntity, GenderDto>();
            CreateMap<GenderDto, GenderEntity>();

            CreateMap<LanguageEntity, LanguageDto>();
            CreateMap<LanguageDto, LanguageEntity>();

            CreateMap<RoleEntity, RoleDto>();
            CreateMap<RoleDto, RoleEntity>();

            CreateMap<SiteStyleTypeEntity, SiteStyleTypeDto>();
            CreateMap<SiteStyleTypeDto, SiteStyleTypeEntity>();

            CreateMap<SystemTypeEntity, SystemTypeDto>();
            CreateMap<SystemTypeDto, SystemTypeEntity>();

            CreateMap<UserEntity, UserDto>();
            CreateMap<UserDto, UserEntity>();

            CreateMap<UserRoleEntity, UserRoleDto>();
            CreateMap<UserRoleDto, UserRoleEntity>();

            CreateMap<VersionHistoryEntity, VersionHistoryDto>();
            CreateMap<VersionHistoryDto, VersionHistoryEntity>();
        }
    }
}
