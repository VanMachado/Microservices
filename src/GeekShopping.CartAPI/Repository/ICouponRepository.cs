using GeekShopping.CartAPI.DataTransfer.DataTransferObjects;

namespace GeekShopping.CartAPI.Repository

{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCouponCode(string couponCode, string token);
    }
}
