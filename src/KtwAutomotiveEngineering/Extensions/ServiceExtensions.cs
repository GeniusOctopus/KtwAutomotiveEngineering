using KtwAutomotiveEngineering.DataAccess;
using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.Service;
using KtwAutomotiveEngineering.Service.Contracts;
using Microsoft.AspNetCore.Identity;

namespace KtwAutomotiveEngineering.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
        }
    }
}
