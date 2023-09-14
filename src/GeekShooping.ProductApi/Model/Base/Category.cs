using System.ComponentModel.DataAnnotations;

namespace GeekShooping.ProductApi.Model.Base
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
