using GeekShooping.ProductApi.DataTransfer.DataTransferObjects;
using GeekShooping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> FindAll()
        {
            var category = await _repository.FindAll();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
