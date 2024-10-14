using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;

namespace Alta_Flight.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDBContext _context;

        public RoleService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Roles>> GetAllRolesAsync()
        {
            return await _context.Role.ToListAsync();
        }

        public async Task<Roles> GetRoleByIdAsync(int id)
        {
            return await _context.Role.FindAsync(id);
        }

        public async Task CreateRoleAsync(Roles role)
        {
            await _context.Role.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Roles role)
        {
            _context.Role.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.Role.FindAsync(id);
            if (role != null)
            {
                _context.Role.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
