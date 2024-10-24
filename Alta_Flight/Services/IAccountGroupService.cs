using Alta_Flight.Model;
using System.Text.RegularExpressions;

namespace Alta_Flight.Services
{
    public interface IAccountGroupService
    {
        //Task<List<Account_Groups>> GetAllAccountGroupsAsync();
        //Task<Account_Groups> GetAccountGroupByIdAsync(int accountGroupId);
        //Task AddAccountToGroupAsync(int accountId, int groupId);
        //Task UpdateAccountGroupAsync(int accountGroupId, int groupId);
        //Task RemoveAccountFromGroupAsync(int accountId, int groupId);

        Task<IEnumerable<Account_Groups>> GetAllAccountGroupAsync();
        Task<Account_Groups> GetAccountGroupByIdAsync(int id);
        Task CreateAccountGroupAsync(Account_Groups acc_groups);
        Task UpdateAccountGroupAsync(Account_Groups acc_groups);
        Task DeleteAccountGroupAsync(int id);
    }
}
