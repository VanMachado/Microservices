using GeekShopping.CouponAPI.DataTransfer.DataTransferObjects;

namespace GeekShooping.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCouponCode(string couponCode);
    }
}
