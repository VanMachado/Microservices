using AutoMapper;
using GeekShooping.ProductApi.DataTransfer.DataTransferObjects;
using GeekShooping.ProductApi.Infra.Data;
using GeekShooping.ProductApi.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> FindAll()
        {
            List<Category> categories = await _context
                .Categories.ToListAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> FindById(long id)
        {
            Category category = await _context
                .Categories.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> Create(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            _context.Categories
                .Add(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }
        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            _context.Categories
                .Update(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Category category = await _context
                    .Categories.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (category == null)
                    return false;

                _context.Remove(category);
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
