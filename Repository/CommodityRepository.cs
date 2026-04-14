using EazyTrade.Data;
using EazyTrade.Interfaces;
using EazyTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Repository
{
    public class CommodityRepository:ICommodityRepository
    {
        private readonly ApplicationDBContext _context;

        public CommodityRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Commodity>> GetAllAsync()
        {
            return await _context.Commodities.ToListAsync();
        }
    }
}