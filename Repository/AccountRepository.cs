using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;

namespace EazyTrade.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}