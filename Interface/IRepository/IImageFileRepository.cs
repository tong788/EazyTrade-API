using EazyTrade.Models;

namespace EazyTrade.Interface.Repository
{
    public interface IImageFileRepository : IRepositoryBase<ImageFile>
    {
        public Task<ImageFile?> GetImageByReferenceAsync(int referenceId, string referenceType);
    }
}
