using AutoMapper;
using KtwAutomotiveEngineering.Entities.ConfigurationModels;
using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.Service.Contracts.Services.Identity;
using KtwAutomotiveEngineering.Service.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;

namespace KtwAutomotiveEngineering.Service
{
    public class ServiceManager(UserManager<AppUser> userManager,
                                IConfiguration configuration,
                                IMapper mapper,
                                ILogger logger,
                                IOptions<JwtConfiguration> jwtConfiguration) : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService = new(() => new AuthenticationService(userManager, configuration, mapper, logger, jwtConfiguration));

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
