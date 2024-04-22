using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.Service.Contracts.Services.Identity;
using KtwAutomotiveEngineering.Service.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace KtwAutomotiveEngineering.Service
{
    public class ServiceManager(UserManager<AppUser> userManager,
                                IConfiguration configuration) : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService = new(() => new AuthenticationService(userManager, configuration));

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
