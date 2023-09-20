using GeekShooping.ProductApi.DataTransfer.DataTransferObjects;

namespace GeekShooping.ProductApi.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> FindAll();
        Task<CategoryDto> FindById(long id);
        Task<CategoryDto> Create(CategoryDto categoryDto);
        Task<CategoryDto> Update(CategoryDto categoryDto);
        Task<bool> Delete(long id);
    }
}
