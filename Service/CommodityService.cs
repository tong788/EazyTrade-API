using EazyTrade.Dto;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Mapper;
using EazyTrade.Models;
using Mapster;

namespace EazyTrade.Service
{
    public class CommodityService : ICommodityService
    {
        private readonly ICommodityRepository _repository;
        public CommodityService(ICommodityRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CommodityDto>> GetCommodities(bool trackChanges)
        {
            var queries = await _repository.GetAllAsync();
            return queries.Select(query => query.Adapt<CommodityDto>()).ToList();
        }

        public async Task<CommodityDto?> GetCommodityById(int id, bool trackChanges)
        {
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                return null;
            }
            return query.Adapt<CommodityDto>();
        }

        public async Task<CommodityDto> CreateCommodity(CommodityForManipulationDto payload)
        {
            var entity = payload.Adapt<Commodity>();
            await _repository.CreateAsync(entity);
            return entity.Adapt<CommodityDto>();
        }

        public async Task<CommodityDto?> UpdateCommodity(int id, CommodityForManipulationDto payload)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            payload.Adapt(entity);
            entity.UpdateAt = DateTime.UtcNow;

            await _repository.UpdateAsync(id, entity);
            return entity.Adapt<CommodityDto>();
        }

        public async Task<bool> DeleteCommodity(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}