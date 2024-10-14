using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;

namespace Alta_Flight.Services
{
    public class AccountService:IAccountService
    {
        private readonly AppDBContext _context;

        public AccountService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Accounts>> GetAllAccountsAsync()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Accounts> GetAccountByIdAsync(int id)
        {
            return await _context.Account.FindAsync(id);
        }

        public async Task CreateAccountAsync(Accounts account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Accounts account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account != null)
            {
                _context.Account.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
