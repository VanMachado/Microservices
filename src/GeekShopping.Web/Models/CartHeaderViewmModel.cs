﻿namespace GeekShopping.Web.Models
{
    public class CartHeaderViewmModel
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
        public double PurchaseAmount { get; set; }
    }
}
