using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
    }
}
