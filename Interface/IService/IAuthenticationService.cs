using EazyTrade.Dto;

namespace EazyTrade.Interface.Service
{
    public interface IAuthenticationService
    {
        public Task<(LoginResponseDto, string)> Login(LoginRequestDto request);
        public Task<AccountDto> Register(RegisterRequestDto request);
    }
}