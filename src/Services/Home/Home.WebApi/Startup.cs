using AutoMapper;
using Generic.Framework.Helpers;
using Home.Framework.Extensions;
using Home.WebApi.Controllers;
using Home.WebApi.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Home.WebApi
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

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // Services, Mappers, Repositories and Database connection. 
            services.AddHomeFramework(configuration: Configuration);

            // AutoMapper (Controller) 
            services.AddAutoMapper(x => x.AddProfile(new ControllerAutoMapperProfile()));

            // Set up dependency injection for controller's logger (Controller) 
            services.AddScoped<ILogger, Logger<AlbumsController>>();
            services.AddScoped<ILogger, Logger<ContactsController>>();
            services.AddScoped<ILogger, Logger<VersionHistoriesController>>();
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
