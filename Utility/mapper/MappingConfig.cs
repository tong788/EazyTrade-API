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

            // Account Mappings
            TypeAdapterConfig<Account, AccountDto>.NewConfig();
            TypeAdapterConfig<AccountForManipulationDto, Account>.NewConfig()
                .Map(dest => dest.CreateAt, src => DateTime.UtcNow)
                .Map(dest => dest.UpdateAt, src => DateTime.UtcNow);

            // Store Mappings
            TypeAdapterConfig<Store, StoreDto>.NewConfig();
            TypeAdapterConfig<StoreForManipulationDto, Store>.NewConfig()
                .Map(dest => dest.CreateAt, src => DateTime.UtcNow)
                .Map(dest => dest.UpdateAt, src => DateTime.UtcNow);

            // StoreAccount Mappings
            TypeAdapterConfig<StoreAccount, StoreAccountDto>.NewConfig();
            TypeAdapterConfig<StoreAccountForManipulationDto, StoreAccount>.NewConfig()
                .Map(dest => dest.CreateAt, src => DateTime.UtcNow)
                .Map(dest => dest.UpdateAt, src => DateTime.UtcNow);
        }
    }
}