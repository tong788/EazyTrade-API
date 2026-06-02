using EazyTrade.Dto;
using EazyTrade.Interface;
using EazyTrade.Interface.Service;
using EazyTrade.Mapper;
using EazyTrade.Models;

namespace EazyTrade.Service
{
    public class CommodityService : ICommodityService
    {
        private readonly ICommodityRepository _repository;
        public CommodityService(ICommodityRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Commodity>> GetCommodities(bool trackChanges)
        {
            var queries = await _repository.GetAll();
            return queries;
        }

        public async Task<Commodity> GetCommodityById(int id, bool trackChanges)
        {
            var query = await _repository.GetById(id);
            return query;
        }

        public async Task CreateCommodity(CommodityForManipulationDto payload)
        {
            var entity = new Commodity
            {
                Name = payload.Name,
                PublishDate = payload.PublishDate,
                Price = payload.Price,
                CancelDate = payload.CancelDate,
            };

            await _repository.Create(entity);
        }

        public async Task UpdateCommodity(int id, CommodityForManipulationDto payload)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return;
            }

            entity.Name = payload.Name;
            entity.PublishDate = payload.PublishDate;
            entity.Price = payload.Price;
            entity.CancelDate = payload.CancelDate;

            await _repository.Update(entity);
        }

        public async Task DeleteCommodity(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return;
            }

            await _repository.Delete(entity);
        }
    }
}