using EazyTrade.Models;
using Microsoft.AspNetCore.Http;

namespace EazyTrade.Interface.Service
{
    public interface IStorageService
    {
        public Task<string> UploadFile(IFormFile file);
        public Task<ImageFile> UploadAndSaveImageAsync(IFormFile file, int referenceId, string referenceType, int userId);
    }
}