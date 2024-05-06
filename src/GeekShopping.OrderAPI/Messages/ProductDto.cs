﻿namespace GeekShopping.OrderAPI.Messages
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
