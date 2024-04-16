using Microsoft.EntityFrameworkCore;

namespace UserRegistration.Model
{
    public class UserDbContext: DbContext 
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public UserDbContext() { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Username);

            modelBuilder.Entity<User>()
            .OwnsOne(u => u.Address);
        }
    }
}
