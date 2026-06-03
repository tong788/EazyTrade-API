using EazyTrade.Models;

namespace EazyTrade.Interface
{
    public interface ICommodityRepository
    {
        Task<List<Commodity>> GetAll();
        Task<Commodity?> GetById(int id);
        Task Create(Commodity payload);
        Task Update(Commodity payload);
        Task Delete(Commodity payload);
    }
}