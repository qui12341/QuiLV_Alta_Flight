using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alta_Flight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IJwtService _jwtService; // Giả sử bạn có một dịch vụ để tạo JWT

        public AuthController(IAccountService accountService, IJwtService jwtService)
        {
            _accountService = accountService;
            _jwtService = jwtService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Xác thực người dùng
            var account = await _accountService.AuthenticateAsync(loginModel.UserName, loginModel.Password);
            if (account == null)
            {
                return Unauthorized();
            }

            // Tạo token JWT
            var token = _jwtService.GenerateToken(account);
            return Ok(new { Token = token });
        }
    }
}
