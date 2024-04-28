using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KtwAutomotiveEngineering.DataAccess
{
    public class RepositoryContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<WorkDay> WorkDay { get; set; }
        public DbSet<WorkTask> WorkTask { get; set; }
        public DbSet<WorkSlice> WorkSlice { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
