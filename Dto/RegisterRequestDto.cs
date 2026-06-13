namespace EazyTrade.Dto
{
    public class RegisterRequestDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Email { get; set; }
    }
}