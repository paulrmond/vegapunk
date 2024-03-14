using Microsoft.EntityFrameworkCore;
using Vegapunk.Services.ShoppingCartAPI.Models;

namespace Vegapunk.Services.ShoppingCartAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        
    }
}
