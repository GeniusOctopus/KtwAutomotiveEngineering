using Microsoft.AspNetCore.Identity;

namespace KtwAutomotiveEngineering.V1.Shared.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
