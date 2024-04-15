using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService category)
        {
            _productService = productService ??
                throw new ArgumentNullException(nameof(productService));
            _categoryService = category ??
                throw new ArgumentNullException(nameof(category));
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var products = await _productService.FindAllProducts(token);
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var categoryList = await _categoryService.FindAllCategories(token);

            var model = new ProductModel
            {
                AvailableCategories = categoryList
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var category = await _categoryService.FindCategoryById(model.CategoryId, token);            
            model.Category = category;                            

            if (ModelState.IsValid)
            {                
                var response = await _productService.CreateProduct(model, token);
                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }
                
        public async Task<IActionResult> ProductUpdate(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id, token);
            var categories = await _categoryService.FindAllCategories(token);
            model.AvailableCategories = categories;

            if (model != null)
                return View(model);

            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProduct(model, token);
                var category = await _categoryService.FindCategoryById(model.CategoryId, token);
                model.Category = category;

                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id, token);
            var category = await _categoryService.FindCategoryById(model.CategoryId, token);
            model.Category = category;
            if (model != null)
                return View(model);

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProductById(model.Id, token);        
            if (response)
            {
                return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }
    }
}
