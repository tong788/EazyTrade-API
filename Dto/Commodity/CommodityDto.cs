using EazyTrade.Dto;

namespace EazyTrade.Dto
{
    public class CommodityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PublishDate { get; set; } = null!;
        public int? Price { get; set; }
        public string Code { get; set; } = null!;
        public ICollection<CommentDto> comments { get; set; } = new List<CommentDto>();
    }
}