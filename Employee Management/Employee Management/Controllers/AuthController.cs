using Employee_Management.EmployeeDTO;
using Employee_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDTO userDTO)
        {
            _userService.RegisterUser(userDTO);
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDTO userDTO)
        {
            var token = _userService.LoginUser(userDTO);
            if (token == null) return Unauthorized("Invalid credentials");

            return Ok(new { token });
        }
    }
}
