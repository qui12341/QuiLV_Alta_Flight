using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Accounts>> GetAllAccountsAsync();
        Task<Accounts> GetAccountByIdAsync(int id);
        Task CreateAccountAsync(Accounts account);
        Task UpdateAccountAsync(Accounts account);
        Task DeleteAccountAsync(int id);
        Task<Accounts> AuthenticateAsync(string userName, string password);

    }
}
