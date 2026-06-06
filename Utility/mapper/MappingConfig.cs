using EazyTrade.Dto;
using EazyTrade.Models;
using Mapster;

namespace EazyTrade.Utility.Mapper
{
    public static class MappingConfiguration
    {
        public static void ConfigureMapping()
        {
            // Commodity Mappings
            TypeAdapterConfig<Commodity, CommodityDto>.NewConfig();
            TypeAdapterConfig<CommodityForManipulationDto, Commodity>.NewConfig()
                .Map(dest => dest.CreateAt, src => DateTime.UtcNow)
                .Map(dest => dest.UpdateAt, src => DateTime.UtcNow);

            // Comment Mappings
            TypeAdapterConfig<Comment, CommentDto>.NewConfig();
            TypeAdapterConfig<CommentForManipulationDto, Comment>.NewConfig()
                .Map(dest => dest.CreateAt, src => DateTime.UtcNow)
                .Map(dest => dest.UpdateAt, src => DateTime.UtcNow);
        }
    }
}