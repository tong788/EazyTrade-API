using EazyTrade.Dto;
using EazyTrade.Models;

namespace EazyTrade.Interface.Service
{
    public interface ICommodityService
    {
        Task<List<Commodity>> GetCommodities(bool trackChanges);
        Task<Commodity> GetCommodityById(int id, bool trackChanges);
        Task CreateCommodity(CommodityForManipulationDto payload);
        Task UpdateCommodity(int id, CommodityForManipulationDto payload);
        Task DeleteCommodity(int id);
    }
}