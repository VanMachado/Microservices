using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

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
        public async Task<IEnumerable<CategoryModel>> FindAllCategories(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<CategoryModel>>();
        }

        public async Task<CategoryModel> FindCategoryById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<CategoryModel>();
        }

        public async Task<CategoryModel> CategoryCreate(CategoryModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CategoryModel>();

            throw new Exception("Somenthing went wrong when calling API");
        }

        public async Task<bool> CategoryDeleteById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();

            throw new Exception("Somenthing went wrong when calling API");
        }
    }
}
