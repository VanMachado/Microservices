using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
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

        public async Task <IActionResult> CategoryIndex()
        {
            var categories = await _categoryService.FindAllCategories();
            return View(categories);
        }

        public async Task<IActionResult> CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryModel model)
        {           
            if (ModelState.IsValid)
            {
                var response = await _categoryService.CategoryCreate(model);
                if (response != null)
                    return RedirectToAction(nameof(CategoryIndex));
            }

            return View(model);
        }
    }
}
