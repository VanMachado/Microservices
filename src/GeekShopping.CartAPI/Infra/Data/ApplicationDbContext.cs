using GeekShopping.CartAPI.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
