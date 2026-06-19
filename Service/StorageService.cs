using Amazon.S3;
using Amazon.S3.Model;
using EazyTrade.ConfigurationModels;
using EazyTrade.Interface.Service;
using EazyTrade.Interface.Repository;
using EazyTrade.Models;
using Microsoft.Extensions.Options;

namespace EazyTrade.Service
{
    public class StorageService : IStorageService
    {
        private readonly AwsS3Configuration _awsS3Configuration;
        private readonly IImageFileRepository _imageFileRepository;

        public StorageService(
            IOptions<AwsS3Configuration> awsS3Configuration,
            IImageFileRepository imageFileRepository)
        {
            _awsS3Configuration = awsS3Configuration.Value;
            _imageFileRepository = imageFileRepository;
        }
        public async Task<string> UploadFile(IFormFile file)
        {
            AmazonS3Client client;

            if (!string.IsNullOrEmpty(_awsS3Configuration.Region))
            {
                var region = Amazon.RegionEndpoint.GetBySystemName(_awsS3Configuration.Region);
                if (!string.IsNullOrEmpty(_awsS3Configuration.AccessKey) && !string.IsNullOrEmpty(_awsS3Configuration.SecretKey))
                {
                    client = new AmazonS3Client(_awsS3Configuration.AccessKey, _awsS3Configuration.SecretKey, region);
                }
                else
                {
                    client = new AmazonS3Client(region);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_awsS3Configuration.AccessKey) && !string.IsNullOrEmpty(_awsS3Configuration.SecretKey))
                {
                    client = new AmazonS3Client(_awsS3Configuration.AccessKey, _awsS3Configuration.SecretKey);
                }
                else
                {
                    client = new AmazonS3Client();
                }
            }
            using var stream = file.OpenReadStream();
            var key = $"{DateTime.Now:yyyyMMddhhmmss}{file.FileName}";
            var putObjectRequest = new PutObjectRequest()
            {
                BucketName = _awsS3Configuration.BucketName,
                Key = key,
                InputStream = stream,
                ContentType = file.ContentType
            };

            await client.PutObjectAsync(putObjectRequest);
            return key;
        }

        public async Task<ImageFile> UploadAndSaveImageAsync(IFormFile file, int referenceId, string referenceType, int userId)
        {
            // 1. Upload file to S3
            string uniqueKey = await UploadFile(file);
            string bucketName = !string.IsNullOrEmpty(_awsS3Configuration.BucketName) ? _awsS3Configuration.BucketName : "eazytrade";
            string fileUrl = $"https://{bucketName}.s3.amazonaws.com/{uniqueKey}";

            // 2. Query for existing image file record
            var existingImage = await _imageFileRepository.GetImageByReferenceAsync(referenceId, referenceType);

            if (existingImage != null)
            {
                existingImage.FileName = uniqueKey;
                existingImage.FileUrl = fileUrl;
                existingImage.FileSize = file.Length;
                existingImage.MimeType = file.ContentType;
                existingImage.UpdateAt = DateTime.UtcNow;
                existingImage.UpdateBy = userId;

                await _imageFileRepository.UpdateAsync(existingImage.Id, existingImage);
                return existingImage;
            }
            else
            {
                var newImage = new ImageFile
                {
                    FileName = uniqueKey,
                    FileUrl = fileUrl,
                    FileSize = file.Length,
                    MimeType = file.ContentType,
                    ReferenceId = referenceId,
                    ReferenceType = referenceType,
                    CreateBy = userId,
                    CreateAt = DateTime.UtcNow,
                    UpdateBy = userId,
                    UpdateAt = DateTime.UtcNow
                };

                await _imageFileRepository.CreateAsync(newImage);
                return newImage;
            }
        }
    }
}