using GeekShopping.OrderAPI.Model;

namespace GeekShopping.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader cart);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);        
    }
}
