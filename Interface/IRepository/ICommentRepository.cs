using EazyTrade.Models;

namespace EazyTrade.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task CreateAsync(Comment payload);
        Task UpdateAsync(Comment payload);
        Task DeleteAsync(Comment payload);
    }
}