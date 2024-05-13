using GeekShopping.Email.Infra.Data;
using GeekShopping.Email.Messages;
using GeekShopping.Email.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _context;

        public EmailRepository(DbContextOptions<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task LogEmail(UpdatePaymenteResultMessage message)
        {
            EmailLog email = new EmailLog()
            {
                Email = message.Email,
                SentDate = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created!"
            };

            await using var _db = new ApplicationDbContext(_context);
            _db.Add(email);
            await _db.SaveChangesAsync();
        }
    }
}
