﻿using AutoMapper;
using GeekShopping.CartAPI.DataTransfer.DataTransferObjects;
using GeekShopping.CartAPI.Infra.Data;
using GeekShopping.CartAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartDto> FindCartByUserId(string userId)
        {            
            //Instanciado o cart
            Cart cart = new()
            {
                CartHeader = await _context.CartHeaders.FirstOrDefaultAsync(x => x.UserId == userId),                
            };
            cart.CartDetails = _context.CartDetails
                .Where(p => p.CartHeaderId == cart.CartHeader.Id)
                .Include(p => p.Product).Include(c => c.Category);                      

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> SaveOrUpdateCart(CartDto dto)
        {
            Cart cart = _mapper.Map<Cart>(dto);
            //Checa se o produto ja existe no DB
            var product = await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(
                p => p.Id == dto.CartDetails.FirstOrDefault().ProductId);

            //Caso nao exista, cria o mesmos
            if (product == null)
            {
                var cartDetail = cart.CartDetails.FirstOrDefault();
                var categoryAux = cartDetail.Category;
                var productAux = cartDetail.Product;
                var category = _mapper.Map<Category>(categoryAux);
                productAux.Category = category;
                var prod = _mapper.Map<Product>(productAux);
                _context.Categories.Add(category);
                _context.Products.Add(prod);

                await _context.SaveChangesAsync();


                await _context.SaveChangesAsync();
            }
            //Checa se o CartHeader nao for null
            var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(
                c => c.UserId == cart.CartHeader.UserId);

            if (cartHeader == null)
            {
                _context.CartHeaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();
                await CheckCart(cart);
            }
            else
            {
                //se o CartDetail nao for null
                var cartDetail = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    p => p.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    p.CartHeaderId == cartHeader.Id);

                if (cartDetail == null)
                {
                    //Cria o CartDetail                    
                    await CheckCartHeader(cart, cartHeader);
                }
                else
                {
                    //Atualizando o Count do Produto e CartDetail
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            try
            {
                CartDetail cartDetail = await _context.CartDetails
                    .FirstOrDefaultAsync(p => p.Id == cartDetailsId);

                int total = _context.CartDetails.Where(
                    p => p.CartHeaderId == cartDetail.CartHeaderId).Count();

                _context.CartDetails.Remove(cartDetail);

                if(total == 1)
                {
                    var cartHeaderToRemove = await _context.CartHeaders
                        .FirstOrDefaultAsync(p => p.Id == cartDetail.CartHeaderId);
                    _context.CartHeaders.Remove(cartHeaderToRemove);

                }
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _context.CartHeaders
                        .FirstOrDefaultAsync(p => p.UserId == userId);

            if(cartHeader != null)
            {
                _context.CartDetails.RemoveRange(
                    _context.CartDetails.Where(p => p.CartHeaderId == cartHeader.Id));

                _context.CartHeaders.Remove(cartHeader);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }        

        private async Task CheckCart(Cart cart)
        {
            cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
            cart.CartDetails.FirstOrDefault().Product = null;
            _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        private async Task CheckCartHeader(Cart cart, CartHeader cartHeader)
        {
            cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
            cart.CartDetails.FirstOrDefault().Product = null;
            _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            await _context.SaveChangesAsync();
        }
    }
}
