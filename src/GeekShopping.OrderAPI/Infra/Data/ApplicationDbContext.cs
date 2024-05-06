using GeekShopping.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderAPI.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {       
        public DbSet<OrderDetail> Details { get; set; }
        public DbSet<OrderHeader> Headers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
