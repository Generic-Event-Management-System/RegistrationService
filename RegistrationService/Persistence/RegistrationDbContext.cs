using Microsoft.EntityFrameworkCore;
using RegistrationService.Models.Entities;

namespace RegistrationService.Persistence
{
    public class RegistrationDbContext : DbContext
    {
        DbSet<Registration> Registrations { get; set; }

        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
