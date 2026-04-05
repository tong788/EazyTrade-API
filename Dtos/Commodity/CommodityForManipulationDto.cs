namespace EazyTrade.Dtos
{
    public class CommodityForManipulationDto
    {
        public string Name { get; set; } = null!;

        public DateTime? PublishDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public int? Price { get; set; }

    }
}