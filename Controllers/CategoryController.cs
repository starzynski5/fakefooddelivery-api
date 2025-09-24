using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using fakefooddelivery_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace fakefooddelivery_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            List<Category> categories = await _service.GetAllCategories();

            return Ok(categories);
        }
    }
}
