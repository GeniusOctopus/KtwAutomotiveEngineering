using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.V1.Shared.Dto.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KtwAutomotiveEngineering.Api.V1.Controllers.Identity
{
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    public class AuthenticationController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpPost]
        public async Task<IActionResult> RegiserUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }
    }
}
