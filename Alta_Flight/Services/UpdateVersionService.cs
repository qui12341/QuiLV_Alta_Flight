using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Alta_Flight.Services
{
    public class UpdateVersionService : IUpdateVersionService
    {
        private readonly AppDBContext _context;

        public UpdateVersionService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateUpdateVersionAsync(UpdateVersions updateVersions)
        {
            await _context.UpdateVersion.AddAsync(updateVersions);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUpdateVersionAsync(int id)
        {
            var updateVersions = await _context.UpdateVersion.FindAsync(id);
            if (updateVersions != null)
            {
                _context.UpdateVersion.Remove(updateVersions);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UpdateVersions>> GetAllUpdateVersionAsync()
        {
            return await _context.UpdateVersion.ToListAsync();
        }

        public async Task<UpdateVersions> GetUpdateVersionByIdAsync(int id)
        {
            return await _context.UpdateVersion.FindAsync(id);
        }

        public async Task UpdateUpdateVersionAsync(UpdateVersions updateVersions)
        {
            _context.UpdateVersion.Update(updateVersions);
            await _context.SaveChangesAsync();
        }
    }
}
