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
    [Authorize(Roles = "USER")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Order/New")]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrderRequest request)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            if (userId == 0) return BadRequest();

            ServiceResult<Order> result = await _service.CreateOrder(userId, request);

            if (!result.Success) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpGet("Order/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            if (id == 0) return BadRequest();

            ServiceResult<Order> result = await _service.GetOrderById(id);

            if (!result.Success) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }
    }
}
