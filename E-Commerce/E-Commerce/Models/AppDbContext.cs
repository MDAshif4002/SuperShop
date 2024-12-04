using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<adminlogin> adminlogin { get; set; }
        public DbSet<slider> slider { get; set; }
        public DbSet<miniproduct> miniproduct { get; set; }
        public DbSet<register> register { get; set; }
        public DbSet<product> product { get; set; }
        public DbSet<womenproduct> womenproduct { get; set; }
    }
}
