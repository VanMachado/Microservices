using GeekShooping.CouponAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [Authorize]
        [HttpGet("{couponCode}")]
        public async Task<IActionResult>  FindById(string couponCode)
        {
            var coupon = await _repository.GetCouponByCouponCode(couponCode);
            
            if(coupon == null)
                return NotFound();

            return Ok(coupon);
        }
    }
}