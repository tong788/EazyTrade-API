using EazyTrade.Dto;

namespace EazyTrade.Interface.Service
{
    public interface ICommentService
    {
        public Task<List<CommentDto>> GetCommentsAsync();
        public Task<CommentDto?> GetCommentByIdAsync(int id);
        public Task<CommentDto> CreateCommentAsync(CommentForManipulationDto payload);
        public Task<CommentDto?> UpdateCommentAsync(int id, CommentForManipulationDto payload);
        public Task<bool> DeleteCommentAsync(int id);
    }
}