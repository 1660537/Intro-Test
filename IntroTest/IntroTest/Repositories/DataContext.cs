using IntroTest.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroTest.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasKey(role => new { role.Id });
            modelBuilder.Entity<Passcode>().HasKey(passcode => new { passcode.IdRole, passcode.Code });
            modelBuilder.Entity<Rating>().HasKey(rating => new { rating.IdRole });
            modelBuilder.Entity<UseState>().HasKey(usestate => new { usestate.IdRole });
        }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Passcode> Passcode { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<UseState> UseState { get; set; }
    }
}
