using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.Service.Contracts.Services.Identity;
using KtwAutomotiveEngineering.V1.Shared.Dto.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace KtwAutomotiveEngineering.Service.Services.Identity
{
    public class AuthenticationService(UserManager<AppUser> userManager, IConfiguration configuration) : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IConfiguration _configuration = configuration;

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var appUser = new AppUser
            {
                FirstName = userForRegistration.FirstName,
                LastName = userForRegistration.LastName,
                UserName = userForRegistration.UserName,
                Email = userForRegistration.Email,
            };

            var result = await _userManager.CreateAsync(appUser, userForRegistration.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(appUser, userForRegistration.Roles);
            }

            return result;
        }
    }
}
