using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDBContext context) : base(context)
        {
        }

    }
}