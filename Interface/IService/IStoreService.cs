using EazyTrade.Dto;

namespace EazyTrade.Interface.Service
{
    public interface IStoreService
    {
        public Task<List<StoreDto>> GetStoresAsync();
        public Task<StoreDto?> GetStoreByIdAsync(int id);
        public Task<StoreDto> CreateStoreAsync(StoreForManipulationDto payload);
        public Task<StoreDto?> UpdateStoreAsync(int id, StoreForManipulationDto payload);
        public Task<bool> DeleteStoreAsync(int id);
    }
}