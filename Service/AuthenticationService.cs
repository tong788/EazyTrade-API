using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using Microsoft.IdentityModel.Tokens;

namespace EazyTrade.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly IAccountRepository _repository;

        public AuthenticationService(IConfiguration config, IAccountRepository repository)
        {
            _config = config;
            _repository = repository;
        }


        public async Task<string?> Login(string username, string password)
        {
            var account = await _repository.GetByUsernameAsync(username);
            if (account == null)
            {
                return null;
            }
            var token = await GenerateToken(username);
            return token;
        }

        private async Task<string> GenerateToken(string username)
        {
            var claims = new[]
           {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtConfig:Issuer"],
                audience: _config["JwtConfig:audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtConfig:DurationInMinutes"])),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}