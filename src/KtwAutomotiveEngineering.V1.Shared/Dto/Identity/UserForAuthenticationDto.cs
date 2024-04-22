using System.ComponentModel.DataAnnotations;

namespace KtwAutomotiveEngineering.V1.Shared.Dto.Identity
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
