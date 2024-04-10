using Microsoft.EntityFrameworkCore;
using Vegapunk.Services.OrderAPI.Models;

namespace Vegapunk.Services.OrderAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        
    }
}
