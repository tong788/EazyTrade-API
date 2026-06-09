using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;

namespace EazyTrade.Repository
{
    public class StoreAccountRepository : RepositoryBase<StoreAccount>, IStoreAccountRepository
    {
        public StoreAccountRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}