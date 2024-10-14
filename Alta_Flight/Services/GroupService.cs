using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Alta_Flight.Services
{
    public class GroupService:IGroupService
    {
        private readonly AppDBContext _context;

        public GroupService(AppDBContext context)
        {
            _context = context;
        }

        public async Task CreateGroupAsync(Groups groups)
        {
            await _context.Group.AddAsync(groups);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int id)
        {
            var groups = await _context.Group.FindAsync(id);
            if (groups != null)
            {
                _context.Group.Remove(groups);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Groups>> GetAllGroupAsync()
        {
            return await _context.Group.ToListAsync();
        }

        public async Task<Groups> GetGroupByIdAsync(int id)
        {
            return await _context.Group.FindAsync(id);

        }

        public async Task UpdateGroupAsync(Groups groups)
        {
            _context.Group.Update(groups);
            await _context.SaveChangesAsync();
        }

    }
}
