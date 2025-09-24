using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace fakefooddelivery_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealController : ControllerBase
    {
        public readonly IMealService _service;

        public MealController(IMealService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeals()
        {
            List<MealWithCategoryNameDTO> meals = await _service.GetAllMeals();

            return Ok(meals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealById(int id)
        {
            ServiceResult<MealWithCategoryNameDTO> meal = await _service.GetMealById(id);

            if (!meal.Success)
            {
                return NotFound(meal.ErrorMessage);
            }

            return Ok(meal.Data);
        }
    }
}
