using System.ComponentModel.DataAnnotations;

namespace GeekShopping.CartAPI.Model.Base
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
