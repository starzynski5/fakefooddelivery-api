using System.Security.Claims;
using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fakefooddelivery_api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "OWNER")]
    public class RestaurantController : ControllerBase
    {
        public readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpPost("Meal")]
        public async Task<IActionResult> CreateMeal([FromBody] NewMealRequest request)
        {
            ServiceResult<String> result = await _service.CreateMeal(request);

            if (!result.Success) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpPost("Restaurant/Name")]
        public async Task<IActionResult> ChangeName([FromBody] RestaurantChangeNameRequest request)
        {
            ServiceResult<String> result = await _service.RestaurantChangeName(request);

            if (!result.Success) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpPut("Meal")]
        public async Task<IActionResult> EditMeal([FromBody] EditMealRequest request)
        {
            ServiceResult<String> result = await _service.EditMeal(request);

            if (!result.Success) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpDelete("Meal/{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            ServiceResult<String> result = await _service.DeleteMeal(id);

            if (!result.Success) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }
    }
}
