using GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.DataTransfer.DataTransferObjects
{    
    public class CartDetailDto
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; } 
        public CartHeaderDto CartHeader { get; set; }
        public long ProductId { get; set; } 
        public ProductDto Product { get; set; } 
        public int Count { get; set; }

    }
}
