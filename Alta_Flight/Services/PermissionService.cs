using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Alta_Flight.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly AppDBContext _context;

        public PermissionService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreatePermissionAsync(Permission permission)
        {
            await _context.Permission.AddAsync(permission);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePermissionAsync(int id)
        {
            var permission = await _context.Permission.FindAsync(id);
            if (permission != null)
            {
                _context.Permission.Remove(permission);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionAsync()
        {
            return await _context.Permission.ToListAsync();
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _context.Permission.FindAsync(id);
        }

        public async Task UpdatePermissionAsync(Permission permission)
        {
            _context.Permission.Update(permission);
            await _context.SaveChangesAsync();
        }
    }
}
