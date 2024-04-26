using AutoMapper;
using GeekShopping.CouponAPI.DataTransfer.DataTransferObjects;
using GeekShopping.CouponAPI.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CouponRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            
            return _mapper.Map<CouponDto>(coupon);
        }
    }
}
