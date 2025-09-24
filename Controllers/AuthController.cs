using fakefooddelivery_api.Data;
using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fakefooddelivery_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            RegisterResult result = await _authService.Register(request);

            if (result.Success == false)
            {
                return BadRequest(new { result.ErrorMessage });
            }

            return Ok(new { result.Token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            LoginResult result = await _authService.Login(request);

            if (result.Success == false)
            {
                return BadRequest(new { result.ErrorMessage });
            }

            return Ok(new { result.Token });
        }
    }
}
