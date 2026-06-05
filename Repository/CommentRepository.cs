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

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Comment payload)
        {
            await _context.Comments.AddAsync(payload);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment payload)
        {
            _context.Comments.Update(payload);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment payload)
        {
            _context.Comments.Remove(payload);
            await _context.SaveChangesAsync();
        }
    }
}