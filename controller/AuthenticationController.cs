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

        [Authorize] // <-- require valid cookie that store access token
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            // extract Id from claim
            var accountIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(accountIdClaim))
            {
                return Unauthorized("Invalid user session");
            }

            // parse to int
            if (!int.TryParse(accountIdClaim, out int accountId))
            {
                return BadRequest("Invalid user ID format in session token.");
            }

            var result = await _service.GetMe(accountId);
            return Ok(result);
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

            Response.Cookies.Append("EazyTradeToken", token, cookieOptions);

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