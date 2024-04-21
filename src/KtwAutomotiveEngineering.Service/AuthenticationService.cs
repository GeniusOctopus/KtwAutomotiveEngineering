using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.V1.Shared.Dto.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace KtwAutomotiveEngineering.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

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
