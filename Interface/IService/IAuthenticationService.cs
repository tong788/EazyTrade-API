namespace EazyTrade.Interface.Service
{
    public interface IAuthenticationService
    {
        public Task<string?> Login(string username, string password);
    }
}