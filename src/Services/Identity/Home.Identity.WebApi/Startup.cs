using AutoMapper;
using Generic.Framework.Helpers;
using Home.Framework.Data;
using Home.Framework.Data.Interfaces;
using Home.Framework.Data.Repositories;
using Home.Framework.Mappers;
using Home.Framework.Services;
using Home.Framework.Services.Interfaces;
using Home.Identity.WebApi.Controllers;
using Home.Identity.WebApi.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Home.Identity.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddControllers();

            services.AddDbContext<HomeDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString").Decrypt()));

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // AutoMapper
            services.AddAutoMapper(x => x.AddProfile(new ServiceAutoMapperProfile()));
            services.AddAutoMapper(x => x.AddProfile(new ControllerAutoMapperProfile()));

            // Set up dependency injection for controller's logger
            services.AddScoped<ILogger, Logger<UsersController>>();

            // Services
            services.AddTransient<IUserService, UserService>();

            // Repositories
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                //app.UseExceptionHandler("/error/customerError");
            }
            else if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
