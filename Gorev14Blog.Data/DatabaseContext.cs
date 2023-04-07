using Gorev14Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorev14Blog.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Gorev14Blog; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Admin",
                    Password = "123",
                    UserName = "Admin",
                    UserGuid = Guid.NewGuid(),
                    RefreshToken = Guid.NewGuid().ToString()
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}