using Alta_Flight.Model;
using System.Text.RegularExpressions;

namespace Alta_Flight.Services
{
    public interface IAccountGroupService
    {
        Task<List<Account_Groups>> GetAllAccountGroupsAsync();
        Task<Account_Groups> GetAccountGroupByIdAsync(int accountGroupId);
        Task AddAccountToGroupAsync(int accountId, int groupId);
        Task UpdateAccountGroupAsync(int accountGroupId, int groupId);
        Task RemoveAccountFromGroupAsync(int accountId, int groupId);
    }
}
