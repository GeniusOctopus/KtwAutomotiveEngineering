using AutoMapper;
using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.ConfigurationModels;
using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.Service.Contracts.Services.Identity;
using KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime;
using KtwAutomotiveEngineering.Service.Services.Identity;
using KtwAutomotiveEngineering.Service.Services.WorkingTime;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;

namespace KtwAutomotiveEngineering.Service
{
    public class ServiceManager(UserManager<AppUser> userManager,
                                IRepositoryManager repositoryManager,
                                IConfiguration configuration,
                                IMapper mapper,
                                ILogger logger,
                                IOptions<JwtConfiguration> jwtConfiguration) : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService = new(() => new AuthenticationService(userManager, configuration, mapper, logger, jwtConfiguration));
        private readonly Lazy<IWorkDayService> _workDayService = new(() => new WorkDayService(repositoryManager, logger, mapper));
        private readonly Lazy<IWorkTaskService> _workTaskService = new(() => new WorkTaskService(repositoryManager, logger, mapper));
        private readonly Lazy<IWorkSliceService> _workSliceService = new(() => new WorkSliceService(repositoryManager, logger, mapper));

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IWorkDayService WorkDayService => _workDayService.Value;
        public IWorkTaskService WorkTaskService => _workTaskService.Value;
        public IWorkSliceService WorkSliceService => _workSliceService.Value;
    }
}
