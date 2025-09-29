using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fakefooddelivery_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        public readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpPost("Restaurant/New")]
        public async Task<IActionResult> CreateRestaurant([FromBody] NewRestaurantRequest request)
        {
            ServiceResult<String> newRestaurantResult = await _service.CreateRestaurant(request);

            if (!newRestaurantResult.Success)
            {
                return BadRequest(newRestaurantResult.ErrorMessage);
            }

            return Ok(newRestaurantResult.Data);
        }

        [HttpPost("Category/New")]
        public async Task<IActionResult> CreateCategory([FromBody] NewCategoryRequest request)
        {
            ServiceResult<String> newCategoryResult = await _service.CreateCategory(request);

            if (!newCategoryResult.Success)
            {
                return BadRequest(newCategoryResult.ErrorMessage);
            }

            return Ok(newCategoryResult.Data);
        }

        [HttpGet("Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            ServiceResult<List<Order>> result = await _service.GetAllOrders();

            return Ok(result.Data);
        }

        [HttpGet("Restaurant/Orders/{restaurantId}")]
        public async Task<IActionResult> GetOrdersOfRestaurant(int restaurantId)
        {
            ServiceResult<List<Order>> result = await _service.GetOrdersOfRestaurant(restaurantId);

            return Ok(result.Data);
        }

        [HttpGet("Orders/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            ServiceResult<Order> result = await _service.GetOrderById(id);

            if (!result.Success) return NotFound(result.ErrorMessage);

            return Ok(result.Data);
        }
    }
}
