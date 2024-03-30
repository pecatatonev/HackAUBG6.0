using HackAUBG6.Core.Contracts;
using HackAUBG6.Core.Services;
using HackAUBG6.Infrastructure.Data;
using HackAUBG6.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace HackAUBG6.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddLogging();

            service.AddScoped<IGetDataService, GetDataService>();
            return service;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                 .AddDefaultIdentity<ApplicationUser>(options =>
                 {
                     options.SignIn.RequireConfirmedAccount = false;
                     options.SignIn.RequireConfirmedEmail = false;
                     options.Password.RequireDigit = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequiredLength = 6;
                 })
                 .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
