using System.Security.Cryptography.X509Certificates;
using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDBContext context) : base(context)
        {
        }
        public async Task<Account?> GetByUsernameAsync(string username)
        {
            var entity = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
            if(entity == null)
            {
                return null;
            }
            return entity;
        }
    }
}