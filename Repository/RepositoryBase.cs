using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        protected readonly ApplicationDBContext _context;
        public RepositoryBase(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task<T> CreateAsync(T payload)
        {
            await _dbSet.AddAsync(payload);
            await _context.SaveChangesAsync();
            return payload;
        }

        public async Task<T?> UpdateAsync(int id, T payload)
        {
            _dbSet.Update(payload);
            await _context.SaveChangesAsync();
            return payload;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = await GetByIdAsync(id);
            if (query == null)
            {
                return false;
            }
            _dbSet.Remove(query);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}