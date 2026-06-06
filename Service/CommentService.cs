using EazyTrade.Dto;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Mapper;
using EazyTrade.Models;
using Mapster;

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
            return queries.Select(c => c.Adapt<CommentDto>()).ToList();
        }

        public async Task<CommentDto?> GetCommentByIdAsync(int id)
        {
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                return null;
            }
            return query.Adapt<CommentDto>();
        }

        public async Task<CommentDto> CreateCommentAsync(CommentForManipulationDto payload)
        {
            var entity = payload.Adapt<Comment>();
            await _repository.CreateAsync(entity);
            return entity.Adapt<CommentDto>();
        }

        public async Task<CommentDto?> UpdateCommentAsync(int id, CommentForManipulationDto payload)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            payload.Adapt(entity);
            entity.UpdateAt = DateTime.UtcNow;

            await _repository.UpdateAsync(id, entity);
            return entity.Adapt<CommentDto>();
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}