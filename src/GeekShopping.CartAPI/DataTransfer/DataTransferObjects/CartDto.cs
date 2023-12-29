namespace GeekShopping.CartAPI.DataTransfer.DataTransferObjects
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailDto> CartDetails { get; set; } = new List<CartDetailDto>();
    }
}
