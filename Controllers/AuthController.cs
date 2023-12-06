using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.UserModel;
using Event_System.Persistance.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Event_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IJwtTokenAuth _jwtTokenAuth;

        public AuthController(UserManager<User> userManager, IConfiguration configuration, IJwtTokenAuth jwtTokenAuth)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtTokenAuth = jwtTokenAuth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email, Full_Name = model.Name };
                string? pass = model.Password ?? throw new ArgumentNullException(nameof(user.Email));
                var result = await _userManager.CreateAsync(user, pass);

                if (result.Succeeded)
                {
                    return Ok(new { Message = "Registration successful" });
                }

                return BadRequest(new { Message = "Registration failed", Errors = result.Errors });
            }

            return BadRequest(new { Message = "Invalid model state" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // Ensure that model.Password is not null before using it
                    if (model.Password != null)
                    {
                        var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);

                        if (isValidPassword)
                        {
                            var token = _jwtTokenAuth.GenerateEncodedToken(user);

                            return Ok(new { Token = token });
                        }
                    }
                    else
                    {
                        return BadRequest(new { Message = "Password cannot be null" });
                    }
                }

                return Unauthorized(new { Message = "Invalid email or password" });
            }

            return BadRequest(new { Message = "Invalid model state" });
        }
    }
}
