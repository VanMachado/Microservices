using GeekShopping.OrderAPI.Infra.Data;
using GeekShopping.OrderAPI.Model;
using GeekShopping.OrderAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _context;

        public OrderRepository(DbContextOptions<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if(header == null)
                return false;
            
            await using var _db = new ApplicationDbContext(_context);
            _db.Headers.Add(header);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            await using var _db = new ApplicationDbContext(_context);
            var header = await _db.Headers.FirstOrDefaultAsync(o => o.Id == orderHeaderId);

            if(header != null)
            {
                header.PaymentStatus = status;
                await _db.SaveChangesAsync();
            };            
        }
    }
}
