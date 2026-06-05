using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Repository
{
    public class CommodityRepository : RepositoryBase<Commodity>, ICommodityRepository
    {

        public CommodityRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}