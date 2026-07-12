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
        private readonly IRoleRepository _roleRepository;

        public AuthenticationService(IConfiguration config, IAccountRepository repository, IRoleRepository roleRepository)
        {
            _config = config;
            _repository = repository;
            _roleRepository = roleRepository;
        }


        public async Task<(LoginResponseDto, string)> Login(LoginRequestDto request)
        {
            var account = await _repository.GetByUsernameAsync(request.Username);
            if (account == null)
            {
                return (null!, null!);
            }

            if (request.Password != account.Password || request.Username != account.Username)
            {
                throw new UnauthorizedAccessException("The username or password is not correct.");
            }
            var token = await GenerateToken(account);

            var response = new LoginResponseDto
            {
                Username = account.Username,
                Firstname = account.Firstname,
                Lastname = account.Lastname,
                Email = account.Email,
                role = account.Role.Name,
                ImageUrl = "", // to be continued
            };

            return (response, token);
        }

        public async Task<AccountDto> Register(RegisterRequestDto request)
        {
            var mappedDto = request.Adapt<Account>();
            var roles = await _roleRepository.GetAllAsync();
            foreach (Role role in roles)
            {
                if (role.Name == request.RoleName)
                {
                    mappedDto.RoleId = role.Id;
                }
            }
            var account = await _repository.CreateAsync(mappedDto);
            var accountDto = account.Adapt<AccountDto>();
            return accountDto;
        }

        private async Task<string> GenerateToken(Account account)
        {
            var claims = new List<Claim>{
                {new Claim(ClaimTypes.Name, account.Username)},
                {new Claim(ClaimTypes.Role, account.Role.Name)}
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