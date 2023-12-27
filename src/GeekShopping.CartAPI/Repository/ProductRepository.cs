using AutoMapper;
using GeekShopping.CartAPI.DataTransfer.DataTransferObjects;
using GeekShopping.CartAPI.Infra.Data;
using GeekShopping.CartAPI.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;        
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> FindAll()
        {            
            List<Product> products = await _context
                .Products.Include(p => p.Category).ToListAsync();                       

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> FindById(long id)
        {
            Product product = await _context
                .Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Create(ProductDto productDto)
        {
            var category = await _context.Categories.FindAsync(productDto.CategoryId);            
            Product product = _mapper.Map<Product>(productDto);
            product.Category = category;
            
            _context.Products
                .Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }
        public async Task<ProductDto> Update(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            Category category = await _context.Categories.FindAsync(productDto.CategoryId);
            product.Category = category;
            _context.Products
                .Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context
                    .Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (product == null)
                    return false;

                _context.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
