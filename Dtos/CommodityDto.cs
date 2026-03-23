using EazyTrade.Models;

namespace EazyTrade.Dtos
{
    public class CommodityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Comment> comments { get; set; } = new List<Comment>();
    }
}