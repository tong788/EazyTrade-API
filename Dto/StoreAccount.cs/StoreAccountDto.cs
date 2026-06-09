using EazyTrade.Models;

namespace EazyTrade.Dto
{
    public class StoreAccountDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int StoreId { get; set; }
        public virtual Account Account { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
    }
}