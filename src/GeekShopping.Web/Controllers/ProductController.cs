using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            var category = await _categoryService.FindCategoryById(model.CategoryId);
            model.Category = category;

            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var model = await _productService.FindProductById(id);
            var category = await _categoryService.FindCategoryById(model.CategoryId);
            model.Category = category;

            if (model != null)
                return View(model);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model);
                var category = await _categoryService.FindCategoryById(model.CategoryId);
                model.Category = category;

                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var model = await _productService.FindProductById(id);
            var category = await _categoryService.FindCategoryById(model.CategoryId);
            model.Category = category;
            if (model != null)
                return View(model);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var response = await _productService.DeleteProductById(model.Id);        
            if (response)
            {
                return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }
    }
}
