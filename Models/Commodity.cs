namespace EazyTrade.Models
{
    public class Commodity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime PublishedDate { get; set;}
        public ICollection<Comment> comments{ get; set; } = new List<Comment>();
    }

}