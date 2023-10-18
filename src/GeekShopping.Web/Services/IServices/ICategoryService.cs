using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> FindAllCategories(string token);
        Task<CategoryModel> FindCategoryById(long id, string token);
        Task<CategoryModel> CategoryCreate(CategoryModel model, string token);
        Task<bool> CategoryDeleteById(long id, string token);
    }
}
