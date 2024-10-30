using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; // Thêm thư viện BCrypt

namespace Alta_Flight.Services
{
    public class AccountService : IAccountService
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
            // Mã hóa mật khẩu trước khi lưu
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Accounts account)
        {
            if (!string.IsNullOrEmpty(account.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
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

        public async Task<Accounts> AuthenticateAsync(string userName, string password)
        {
            var account = await _context.Account
                .FirstOrDefaultAsync(a => a.UserName == userName);

            // Nếu tìm thấy tài khoản, kiểm tra mật khẩu
            if (account != null && BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return account; 
            }

            return null;
        }
    }
}
