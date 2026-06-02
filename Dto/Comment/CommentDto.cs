using EazyTrade.Models;

namespace EazyTrade.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Comment> comments { get; set; } = new List<Comment>();
    }
}