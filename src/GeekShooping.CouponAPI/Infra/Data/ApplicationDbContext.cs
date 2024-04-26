using GeekShopping.CouponAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1,
                CouponCode = "Batata_2024",
                DiscountAmount = 10
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "Macaxeira_2024",
                DiscountAmount = 15
            });
        }
    }
}
