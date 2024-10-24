using Alta_Flight.Data;
using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

public class AccountGroupService : IAccountGroupService
{
    private readonly AppDBContext _context;

    public AccountGroupService(AppDBContext context)
    {
        _context = context;
    }

    public async Task CreateAccountGroupAsync(Account_Groups acc_groups)
    {
        await _context.Account_Group.AddAsync(acc_groups);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAccountGroupAsync(int id)
    {
        var acc_groups = await _context.Account_Group.FindAsync(id);
        if (acc_groups != null)
        {
            _context.Account_Group.Remove(acc_groups);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Account_Groups> GetAccountGroupByIdAsync(int id)
    {
        return await _context.Account_Group.FindAsync(id);
    }

    public async Task<IEnumerable<Account_Groups>> GetAllAccountGroupAsync()
    {
        return await _context.Account_Group.ToListAsync();
    }

    public async Task UpdateAccountGroupAsync(Account_Groups acc_groups)
    {
        _context.Account_Group.Update(acc_groups);
        await _context.SaveChangesAsync();
    }
}
