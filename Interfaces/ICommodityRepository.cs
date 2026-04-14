using EazyTrade.Models;

namespace EazyTrade.Interfaces
{
    public interface ICommodityRepository
    {
       Task<List<Commodity>> GetAllAsync();
    }
}