namespace GeekShooping.ProductApi.DataTransfer.DataTransferObjects
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

        public string ImageUrl { get; set; }
    }
}
