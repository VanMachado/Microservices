using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public CategoryModel Category { get; set; }        
        public string ImageUrl { get; set; }
        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubstringName()
        {
            if(Name.Length < 24)
            {
                return Name;
            }

            return $"{Name.Substring(0, 21)} ...";
        }

        public string SubstringDescription()
        {
            if (Description.Length < 355)
            {
                return Name;
            }

            return $"{Description.Substring(0, 352)} ...";
        }
    }
}
