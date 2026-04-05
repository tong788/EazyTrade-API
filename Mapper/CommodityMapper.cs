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

        public static Commodity ToCommodityFromManipulation(this CommodityForManipulationDto commodityForManipulationDto)
        {
            return new Commodity
            {
                Name = commodityForManipulationDto.Name,
                Price = commodityForManipulationDto.Price,
                PublishDate = commodityForManipulationDto.PublishDate,
                CancelDate = commodityForManipulationDto.CancelDate
            };
        }
    }
}