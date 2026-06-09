using EazyTrade.Dto;

namespace EazyTrade.Interface.Service
{
    public interface IStoreAccountService
    {
        public Task<List<StoreAccountDto>> GetStoreAccountsAsync();
        public Task<StoreAccountDto?> GetStoreAccountByIdAsync(int id);
        public Task<StoreAccountDto> CreateStoreAccountAsync(StoreAccountForManipulationDto payload);
        public Task<StoreAccountDto?> UpdateStoreAccountAsync(int id, StoreAccountForManipulationDto payload);
        public Task<bool> DeleteStoreAccountAsync(int id);
    }
}