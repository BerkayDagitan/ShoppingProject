using API.DTO;
using API.Entity;
using API.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return BadRequest(new ProblemDetails { Title = "Username is incorrect" });
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (result)
            {
                return Ok(new { token = await _tokenService.GenerateToken(user) });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(RegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                return StatusCode(201);
            }

            return BadRequest(result.Errors);
        }
    }
}
