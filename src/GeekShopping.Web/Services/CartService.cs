﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        private const string BasePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException();
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/add-cart", cart);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();

            else throw new Exception($"Somenthing went wrong when calling API.");
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel cart, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/update-cart", cart);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();

            else throw new Exception("Somenthing went wrong when calling API");
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();

            throw new Exception("Somenthing went wrong when calling API");
        }

        public async Task<bool> ApplyCoupon(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/apply-coupon", model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();

            throw new Exception("Somenthing went wrong when calling API");
        }

        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/remove-coupon/{userId}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();

            throw new Exception("Somenthing went wrong when calling API");
        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<object> Checkout(CartHeaderViewmModel cartHeader, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/checkout", cartHeader);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartHeaderViewmModel>();
            else if (response.StatusCode.ToString().Equals("PreconditionFailed"))
                return "Coupon Price has changed, please confirm!";

            throw new Exception("Somenthing went wrong when calling API");
        }
    }
}
