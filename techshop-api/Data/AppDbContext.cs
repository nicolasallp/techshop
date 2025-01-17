using Microsoft.EntityFrameworkCore;
using techshop_api.Models;

namespace techshop_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Admin> Admins { get; set; }
    }
}
