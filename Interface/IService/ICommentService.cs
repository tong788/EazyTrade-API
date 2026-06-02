using EazyTrade.Models;

namespace EazyTrade.Interface.Service
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsAsync();
    }
}