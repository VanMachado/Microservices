using GeekShooping.ProductApi.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductApi.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }        
    }
}
