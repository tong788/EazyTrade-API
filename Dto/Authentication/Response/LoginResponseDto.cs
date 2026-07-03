using EazyTrade.Models;

namespace EazyTrade.Dto
{
    public class LoginResponseDto
    {
        public string Username { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Email { get; set; }
        public string role { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}