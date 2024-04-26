namespace GeekShopping.CouponAPI.DataTransfer.DataTransferObjects
{
    public class CouponDto
    {
        public long Id { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
