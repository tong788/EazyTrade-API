using EazyTrade.Data;
using EazyTrade.Interface;
using EazyTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Repository
{
    public class CommodityRepository : ICommodityRepository
    {
        private readonly ApplicationDBContext _context;

        public CommodityRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Commodity>> GetAll()
        {
            return await _context.Commodities.ToListAsync();
        }
        public async Task<Commodity?> GetById(int id)
        {
            return await _context.Commodities.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task Create(Commodity payload)
        {
            await _context.Commodities.AddAsync(payload);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Commodity payload)
        {
            _context.Commodities.Update(payload);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Commodity payload)
        {
            _context.Commodities.Remove(payload);
            await _context.SaveChangesAsync();
        }
    }
}