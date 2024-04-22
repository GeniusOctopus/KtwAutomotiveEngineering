using KtwAutomotiveEngineering.Service.Contracts.Services.Identity;

namespace KtwAutomotiveEngineering.Service.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
    }
}
