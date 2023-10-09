using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> FindAllCategories();
        Task<CategoryModel> FindCategoryById(long id);
        Task<CategoryModel> CategoryCreate(CategoryModel model);
    }
}
