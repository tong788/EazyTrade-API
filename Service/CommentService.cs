using EazyTrade.Dto;
using EazyTrade.Interface;
using EazyTrade.Interface.Service;
using EazyTrade.Mapper;
using EazyTrade.Models;

namespace EazyTrade.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<CommentDto>> GetCommentsAsync()
        {
            var queries = await _repository.GetAllAsync();
            return queries.Select(c => c.ToCommentDto()).ToList();
        }

        public async Task<CommentDto?> GetCommentByIdAsync(int id)
        {
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                return null;
            }
            return query.ToCommentDto();
        }

        public async Task<CommentDto> CreateCommentAsync(CommentForManipulationDto payload)
        {
            var entity = payload.ToCommentFromManipulation();
            await _repository.CreateAsync(entity);
            return entity.ToCommentDto();
        }

        public async Task<CommentDto?> UpdateCommentAsync(int id, CommentForManipulationDto payload)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            entity.Detail = payload.Detail;
            entity.CommodityId = payload.CommodityId;
            entity.UpdateAt = DateTime.UtcNow;

            await _repository.UpdateAsync(entity);
            return entity.ToCommentDto();
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            await _repository.DeleteAsync(entity);
            return true;
        }
    }
}