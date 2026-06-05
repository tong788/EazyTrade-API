namespace EazyTrade.Interface.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<T> CreateAsync(T payload);
        public Task<T?> UpdateAsync(int id, T payload);
        public Task<bool> DeleteAsync(int id);
    };
}