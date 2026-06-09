using EazyTrade.Dto;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Models;
using Mapster;

namespace EazyTrade.Service
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _repository;
        public StoreService(IStoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StoreDto>> GetStoresAsync()
        {
            var queries = await _repository.GetAllAsync();
            return queries.Select(s => s.Adapt<StoreDto>()).ToList();
        }

        public async Task<StoreDto?> GetStoreByIdAsync(int id)
        {
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                return null;
            }
            return query.Adapt<StoreDto>();
        }

        public async Task<StoreDto> CreateStoreAsync(StoreForManipulationDto payload)
        {
            var entity = payload.Adapt<Store>();
            await _repository.CreateAsync(entity);
            return entity.Adapt<StoreDto>();
        }

        public async Task<StoreDto?> UpdateStoreAsync(int id, StoreForManipulationDto payload)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            payload.Adapt(entity);
            entity.UpdateAt = DateTime.UtcNow;

            await _repository.UpdateAsync(id, entity);
            return entity.Adapt<StoreDto>();
        }

        public async Task<bool> DeleteStoreAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}