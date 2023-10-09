using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;
        private const string BasePath = "api/v1/category";

        public CategoryService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException();
        }
        public async Task<IEnumerable<CategoryModel>> FindAllCategories()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<CategoryModel>>();
        }

        public async Task<CategoryModel> FindCategoryById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<CategoryModel>();
        }
    }
}
