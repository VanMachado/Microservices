﻿using GeekShopping.CartAPI.Model.Base;

namespace GeekShopping.CartAPI.DataTransfer.DataTransferObjects
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
