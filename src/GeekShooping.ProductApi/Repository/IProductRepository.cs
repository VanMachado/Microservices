using GeekShooping.ProductApi.DataTransfer.DataTransferObjects;
using GeekShooping.ProductApi.Model.Base;

namespace GeekShooping.ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAll();
        Task<ProductDto> FindById(long id);
        Task<ProductDto> Create(ProductDto product);
        Task<ProductDto> Update(ProductDto product);
        Task<bool> Delete(long id);
    }
}
