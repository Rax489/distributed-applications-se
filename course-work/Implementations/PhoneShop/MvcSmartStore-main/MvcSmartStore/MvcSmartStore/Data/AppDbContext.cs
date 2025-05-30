using Microsoft.EntityFrameworkCore;
using MvcSmartStore.Models;

namespace MvcSmartStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
