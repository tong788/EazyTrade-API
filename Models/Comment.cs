namespace EazyTrade.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Detail { get; set; } = null!;
        public Commodity Commodity { get; set; } = null!;
    }

}