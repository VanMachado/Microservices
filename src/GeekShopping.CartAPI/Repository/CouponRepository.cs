using GeekShopping.CartAPI.DataTransfer.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.CartAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _client;        

        public CouponRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<CouponDto> GetCoupon(string couponCode, string token)
        {            
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"/api/v1/Coupon/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return new CouponDto();

            return JsonSerializer.Deserialize<CouponDto>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
