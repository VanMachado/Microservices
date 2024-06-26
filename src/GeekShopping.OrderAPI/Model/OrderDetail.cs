﻿using GeekShopping.OrderAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.OrderAPI.Model
{
    [Table("order_detail")]
    public class OrderDetail : BaseEntity
    {
        public long OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeader OrderHeader { get; set; }
        [Column("count")]
        public int Count { get; set; }
        [Column("productId")]
        public long ProductId { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
    }
}
