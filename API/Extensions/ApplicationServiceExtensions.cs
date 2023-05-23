using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions // Add services to the services container
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) // (this IServiceCollection services) This will allow us to use this method as an extension method.
        {
            services.AddDbContext<DataContext>(options =>
            { // This will add the DataContext to the services collection.
                options.UseSqlite(config.GetConnectionString("DefaultConnection")); // This will use the connection string from the appsettings.json file.
            });
            services.AddCors(); // This will allow the API to accept requests from any origin.
            services.AddScoped<ITokenService, TokenService>(); // This will add the TokenService to the services container.
            services.AddScoped<IUserRepository, UserRepository>(); // This will add the UserRepository to the services container.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // This will add the AutoMapper to the services container.
            
            return services;
        }
    }
}