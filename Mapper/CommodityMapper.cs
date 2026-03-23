using EazyTrade.Dtos;
using EazyTrade.Models;

namespace EazyTrade.Mapper
{
    public static class CommodityMapper
    {
        public static CommodityDto ToCommodityDto(this Commodity commodityModel)
        {
            return new CommodityDto
            {
                Id = commodityModel.Id,
                Name = commodityModel.Name
            };
        }
    }
}