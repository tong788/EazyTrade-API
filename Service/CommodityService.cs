using EazyTrade.Dto;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Mapper;

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
            return queries.Select(query => query.ToCommodityDto()).ToList();
        }

        public async Task<CommodityDto?> GetCommodityById(int id, bool trackChanges)
        {
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                return null;
            }
            return query.ToCommodityDto();
        }

        public async Task<CommodityDto> CreateCommodity(CommodityForManipulationDto payload)
        {
            var entity = payload.ToCommodityFromManipulation();
            await _repository.CreateAsync(entity);
            return entity.ToCommodityDto();
        }

        public async Task<CommodityDto?> UpdateCommodity(int id, CommodityForManipulationDto payload)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            entity.Name = payload.Name;
            entity.PublishDate = payload.PublishDate;
            entity.Price = payload.Price;
            entity.CancelDate = payload.CancelDate;
            entity.UpdateAt = DateTime.UtcNow;

            await _repository.UpdateAsync(id, entity);
            return entity.ToCommodityDto();
        }

        public async Task<bool> DeleteCommodity(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}