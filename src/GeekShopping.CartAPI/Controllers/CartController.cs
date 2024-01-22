using GeekShopping.CartAPI.DataTransfer.DataTransferObjects;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentException(nameof(repository));
        }

        [HttpGet("find-cart/{id}")]        
        public async Task<ActionResult<CartDto>> FindById(string id)
        {
            var cart = await _repository.FindCartByUserId(id);

            if (cart == null)
                return NotFound();

            return Ok(cart);
        }
        
        [HttpPost("add-cart")]        
        public async Task<ActionResult<CartDto>> AddCart(CartDto dto)
        {
            var cart = await _repository.SaveOrUpdateCart(dto);

            if (cart == null)
                return NotFound();

            return Ok(cart);
        }
        
        [HttpPut("update-cart")]        
        public async Task<ActionResult<CartDto>> UpdateCart(CartDto dto)
        {
            var cart = await _repository.SaveOrUpdateCart(dto);

            if (cart == null)
                return NotFound();

            return Ok(cart);
        }
        
        [HttpDelete("remove-cart/{id}")]        
        public async Task<ActionResult<CartDto>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);

            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
