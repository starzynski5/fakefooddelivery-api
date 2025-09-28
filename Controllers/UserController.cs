using fakefooddelivery_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fakefooddelivery_api.Controllers
{
    public class UserController : ControllerBase
    {
        public readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
    }
}
