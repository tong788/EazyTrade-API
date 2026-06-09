using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;

namespace EazyTrade.Repository
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}