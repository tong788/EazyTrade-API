using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;

namespace EazyTrade.Repository
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
