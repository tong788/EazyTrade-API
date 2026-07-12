using EazyTrade.Interface.Service;
using EazyTrade.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EazyTrade.Controller
{
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;
        private readonly IConfiguration _config;
        public AuthenticationController(IAuthenticationService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (result, token) = await _service.Login(request);
            if (result == null)
            {
                return Unauthorized();
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // HTTPS only
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddMinutes(Convert.ToDouble(_config["JwtConfig:DurationInMinutes"]))
            };

            Response.Cookies.Append("token", token, cookieOptions);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Register(request);

            return Ok(result);
        }
    }
}