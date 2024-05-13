using GeekShopping.CartAPI.DataTransfer.DataTransferObjects;

namespace GeekShopping.CartAPI.Repository

{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponCode, string token);
    }
}
