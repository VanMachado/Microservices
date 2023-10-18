using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ??
                throw new ArgumentNullException(nameof(categoryService)); ;
        }

        [Authorize]
        public async Task <IActionResult> CategoryIndex()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var categories = await _categoryService.FindAllCategories(token);
            return View(categories);
        }

        public async Task<IActionResult> CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CategoryCreate(CategoryModel model)
        {           
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _categoryService.CategoryCreate(model, token);
                if (response != null)
                    return RedirectToAction(nameof(CategoryIndex));
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _categoryService.FindCategoryById(id, token);
            if (model != null)
                return View(model);

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> CategoryDelete(ProductModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _categoryService.CategoryDeleteById(model.Id, token);
            if (response)
                return RedirectToAction(nameof(CategoryIndex));

            return View(model);
        }
    }
}
