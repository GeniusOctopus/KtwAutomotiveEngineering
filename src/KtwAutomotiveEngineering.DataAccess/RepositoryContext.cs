using KtwAutomotiveEngineering.V1.Shared.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KtwAutomotiveEngineering.DataAccess
{
    public class RepositoryContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
