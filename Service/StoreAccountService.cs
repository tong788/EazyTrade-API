using EazyTrade.Dto;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Models;
using Mapster;

namespace EazyTrade.Service
{
    public class StoreAccountService : IStoreAccountService
    {
        private readonly IStoreAccountRepository _repository;
        public StoreAccountService(IStoreAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StoreAccountDto>> GetStoreAccountsAsync()
        {
            var queries = await _repository.GetAllAsync();
            return queries.Select(sa => sa.Adapt<StoreAccountDto>()).ToList();
        }

        public async Task<StoreAccountDto?> GetStoreAccountByIdAsync(int id)
        {
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                return null;
            }
            return query.Adapt<StoreAccountDto>();
        }

        public async Task<StoreAccountDto> CreateStoreAccountAsync(StoreAccountForManipulationDto payload)
        {
            var entity = payload.Adapt<StoreAccount>();
            await _repository.CreateAsync(entity);
            return entity.Adapt<StoreAccountDto>();
        }

        public async Task<StoreAccountDto?> UpdateStoreAccountAsync(int id, StoreAccountForManipulationDto payload)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            payload.Adapt(entity);
            entity.UpdateAt = DateTime.UtcNow;

            await _repository.UpdateAsync(id, entity);
            return entity.Adapt<StoreAccountDto>();
        }

        public async Task<bool> DeleteStoreAccountAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}