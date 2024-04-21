using KtwAutomotiveEngineering.V1.Shared.Dto.Identity;
using Microsoft.AspNetCore.Identity;

namespace KtwAutomotiveEngineering.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
    }
}
