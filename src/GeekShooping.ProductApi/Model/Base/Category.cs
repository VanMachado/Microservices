using System.ComponentModel.DataAnnotations;

namespace GeekShooping.ProductApi.Model.Base
{
    public class Category : BaseEntity
    {        
        [StringLength(150)]
        public string Name { get; set; }
    }
}
