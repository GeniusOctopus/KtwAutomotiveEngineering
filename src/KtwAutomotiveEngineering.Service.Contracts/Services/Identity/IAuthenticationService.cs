using KtwAutomotiveEngineering.V1.Shared.Dto.Identity;
using Microsoft.AspNetCore.Identity;

namespace KtwAutomotiveEngineering.Service.Contracts.Services.Identity
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistration);
    }
}
