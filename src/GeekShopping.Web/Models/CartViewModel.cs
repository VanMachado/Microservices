namespace GeekShopping.Web.Models
{
    public class CartViewModel
    {
        public CartHeaderViewmModel CartHeader { get; set; }
        public IEnumerable<CartDetailViewModel> CartDetails { get; set; } = new List<CartDetailViewModel>();
    }
}
