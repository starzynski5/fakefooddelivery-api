using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
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

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] NewRestaurantRequest request)
        {
            ServiceResult<String> newRestaurantResult = await _service.CreateRestaurant(request);

            if (!newRestaurantResult.Success)
            {
                return BadRequest(newRestaurantResult.ErrorMessage);
            }

            return Ok(newRestaurantResult.Data);
        }
    }
}
