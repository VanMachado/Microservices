using GeekShopping.CartAPI.Model.Base;

namespace GeekShopping.CartAPI.DataTransfer.DataTransferObjects
{
    public class CartHeaderDto
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
