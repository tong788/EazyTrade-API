using EazyTrade.Models;

namespace EazyTrade.Interface.Repository
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        public Task<Account?> GetByUsernameAsync(string username);
    }
}