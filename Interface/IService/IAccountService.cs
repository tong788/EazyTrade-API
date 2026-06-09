using EazyTrade.Dto;

namespace EazyTrade.Interface.Service
{
    public interface IAccountService
    {
        public Task<List<AccountDto>> GetAccountsAsync();
        public Task<AccountDto?> GetAccountByIdAsync(int id);
        public Task<AccountDto> CreateAccountAsync(AccountForManipulationDto payload);
        public Task<AccountDto?> UpdateAccountAsync(int id, AccountForManipulationDto payload);
        public Task<bool> DeleteAccountAsync(int id);
    }
}