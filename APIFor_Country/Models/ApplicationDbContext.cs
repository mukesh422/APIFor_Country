using Microsoft.EntityFrameworkCore;

namespace APIFor_Country.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set;}
        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Userlogin> UserLogins { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}
