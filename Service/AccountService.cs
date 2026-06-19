using EazyTrade.Dto;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Models;
using Mapster;

namespace EazyTrade.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IStorageService _storageService;
        private readonly IImageFileRepository _imageFileRepository;

        public AccountService(
            IAccountRepository repository,
            IStorageService storageService,
            IImageFileRepository imageFileRepository)
        {
            _repository = repository;
            _storageService = storageService;
            _imageFileRepository = imageFileRepository;
        }

        public async Task<List<AccountDto>> GetAccountsAsync()
        {
            var queries = await _repository.GetAllAsync();
            return queries.Select(a => a.Adapt<AccountDto>()).ToList();
        }

        public async Task<AccountDto?> GetAccountByIdAsync(int id)
        {
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                return null;
            }
            var accountDto = query.Adapt<AccountDto>();
            var imageFile = await _imageFileRepository.GetImageByReferenceAsync(id, "Account");
            if (imageFile != null)
            {
                accountDto.ImageUrl = imageFile.FileUrl;
            }
            return accountDto;
        }

        public async Task<AccountDto> CreateAccountAsync(AccountForManipulationDto payload)
        {
            var entity = payload.Adapt<Account>();
            await _repository.CreateAsync(entity);
            return entity.Adapt<AccountDto>();
        }

        public async Task<AccountDto?> UpdateAccountAsync(int id, AccountForManipulationDto payload)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            payload.Adapt(entity);
            entity.UpdateAt = DateTime.UtcNow;

            if (payload.Image != null && payload.Image.Length > 0)
            {
                await _storageService.UploadAndSaveImageAsync(payload.Image, id, "Account", id);
            }

            await _repository.UpdateAsync(id, entity);
            return entity.Adapt<AccountDto>();
        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}