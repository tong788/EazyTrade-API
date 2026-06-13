using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EazyTrade.Dto;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Models;
using Mapster;
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


        public async Task<string?> Login(LoginRequestDto request)
        {
            var account = await _repository.GetByUsernameAsync(request.Username);
            if (account == null)
            {
                return null;
            }
            if (request.Password != account.Password || request.Username != account.Username)
            {
                throw new UnauthorizedAccessException("The username or password is not correct.");
            }
            var token = await GenerateToken(request.Username);
            return token;
        }

        public async Task<AccountDto> Register(RegisterRequestDto request)
        {
            var mappedDto = request.Adapt<Account>();
            var account = await _repository.CreateAsync(mappedDto);
            var accountDto = account.Adapt<AccountDto>();
            return accountDto;
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