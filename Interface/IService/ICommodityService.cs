using EazyTrade.Dto;

namespace EazyTrade.Interface.Service
{
    public interface ICommodityService
    {
        Task<List<CommodityDto>> GetCommodities(bool trackChanges);
        Task<CommodityDto?> GetCommodityById(int id, bool trackChanges);
        Task<CommodityDto> CreateCommodity(CommodityForManipulationDto payload);
        Task<CommodityDto?> UpdateCommodity(int id, CommodityForManipulationDto payload);
        Task<bool> DeleteCommodity(int id);
    }
}