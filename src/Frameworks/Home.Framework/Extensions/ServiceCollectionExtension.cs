using AutoMapper;
using Generic.Framework.Helpers;
using Home.Framework.Data;
using Home.Framework.Data.Interfaces;
using Home.Framework.Data.Repositories;
using Home.Framework.Mappers;
using Home.Framework.Services;
using Home.Framework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Home.Framework.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHomeFramework(this IServiceCollection services, IConfiguration configuration)
        {
            // Service 
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IUserService, UserService>();


            // Repository 
            services.AddScoped<IAlbumRatingRepository, AlbumRatingRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IMusicTypeRepository, MusicTypeRepository>();
            services.AddScoped<IRatingTypeRepository, RatingTypeRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IVersionHistoryRepository, VersionHistoryRepository>();


            // Mappers 
            services.AddAutoMapper(x => x.AddProfile(new ServiceAutoMapperProfile()));


            // Database Connection String 
            services.AddDbContext<HomeDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnectionString").Decrypt()));


            return services;
        }
    }
}
