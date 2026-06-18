namespace EazyTrade.Dto
{
    public class AccountForManipulationDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Email { get; set; }
        public IFormFile? Image { get; set; }
    }
}