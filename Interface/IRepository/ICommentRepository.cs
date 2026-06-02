using EazyTrade.Models;

namespace EazyTrade.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
    }
}