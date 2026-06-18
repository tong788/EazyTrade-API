using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Repository
{
    public class ImageFileRepository : RepositoryBase<ImageFile>, IImageFileRepository
    {
        public ImageFileRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<ImageFile?> GetImageByReferenceAsync(int referenceId, string referenceType)
        {
            return await _context.ImageFiles
                .FirstOrDefaultAsync(img => img.ReferenceId == referenceId && img.ReferenceType == referenceType);
        }
    }
}
