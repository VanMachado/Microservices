namespace GeekShopping.Web.Models
{
    public class ProductViewModel
    {
        public ProductModel Product { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
