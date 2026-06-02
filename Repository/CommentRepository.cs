using EazyTrade.Data;
using EazyTrade.Interface;
using EazyTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            var results = await _context.Comments.ToListAsync();
            return results;
        }
    }
}