namespace EazyTrade.Dto
{
    public class RegisterRequestDto : AuthenticationRequestDto
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Email { get; set; }
        public int RoleId { get; set; }
    }
}