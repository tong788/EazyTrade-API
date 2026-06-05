using EazyTrade.Dto;

namespace EazyTrade.Interface.Service
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetCommentsAsync();
        Task<CommentDto?> GetCommentByIdAsync(int id);
        Task<CommentDto> CreateCommentAsync(CommentForManipulationDto payload);
        Task<CommentDto?> UpdateCommentAsync(int id, CommentForManipulationDto payload);
        Task<bool> DeleteCommentAsync(int id);
    }
}