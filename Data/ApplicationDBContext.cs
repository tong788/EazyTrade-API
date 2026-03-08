using EazyTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        
        public DbSet<Commodity> Commodity { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}