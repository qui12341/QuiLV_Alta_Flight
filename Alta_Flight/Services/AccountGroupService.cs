using Alta_Flight.Data;
using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.EntityFrameworkCore;

public class AccountGroupService : IAccountGroupService
{
    private readonly AppDBContext _context;

    public AccountGroupService(AppDBContext context)
    {
        _context = context;
    }

    // Lấy tất cả các mối quan hệ giữa tài khoản và nhóm
    public async Task<List<Account_Groups>> GetAllAccountGroupsAsync()
    {
        return await _context.Account_Group.ToListAsync();
    }

    // Lấy một mối quan hệ giữa tài khoản và nhóm theo ID
    public async Task<Account_Groups> GetAccountGroupByIdAsync(int accountGroupId)
    {
        return await _context.Account_Group
            .FirstOrDefaultAsync(ag => ag.Id == accountGroupId);  // Giả sử `Id` là khóa chính của Account_Groups
    }

    // Thêm mối quan hệ giữa tài khoản và nhóm
    public async Task AddAccountToGroupAsync(int accountId, int groupId)
    {
        var accountGroup = new Account_Groups
        {
            accountID = accountId,
            group_id = groupId
        };
        _context.Account_Group.Add(accountGroup);
        await _context.SaveChangesAsync();
    }

    // Sửa mối quan hệ giữa tài khoản và nhóm
    public async Task UpdateAccountGroupAsync(int accountGroupId, int groupId)
    {
        var accountGroup = await _context.Account_Group
            .FirstOrDefaultAsync(ag => ag.Id == accountGroupId);

        if (accountGroup != null)
        {
            accountGroup.group_id = groupId;
            await _context.SaveChangesAsync();
        }
    }

    // Xóa mối quan hệ giữa tài khoản và nhóm
    public async Task RemoveAccountFromGroupAsync(int accountId, int groupId)
    {
        var accountGroup = await _context.Account_Group
            .FirstOrDefaultAsync(ag => ag.accountID == accountId && ag.group_id == groupId);

        if (accountGroup != null)
        {
            _context.Account_Group.Remove(accountGroup);
            await _context.SaveChangesAsync();
        }
    }
}
