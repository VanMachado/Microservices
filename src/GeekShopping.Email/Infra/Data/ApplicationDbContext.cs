using GeekShopping.Email.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {       
        public DbSet<EmailLog> Emails { get; set; }        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
