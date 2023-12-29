using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }
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
