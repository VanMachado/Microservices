using System.ComponentModel.DataAnnotations;

namespace GeekShopping.CartAPI.Model.Base
{
    public class Category : BaseEntity
    {        
        [StringLength(150)]
        public string Name { get; set; }
    }
}
