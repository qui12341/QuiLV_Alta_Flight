using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Alta_Flight.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly AppDBContext _context;

        public ConfigurationService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateConfigurationAsync(Configurations configurations)
        {
            await _context.Configuration.AddAsync(configurations);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfigurationAsync(int id)
        {
            var configurations = await _context.Configuration.FindAsync(id);
            if (configurations != null)
            {
                _context.Configuration.Remove(configurations);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Configurations>> GetAllConfigurationAsync()
        {
            return await _context.Configuration.ToListAsync();
        }

        public async Task<Configurations> GetConfigurationByIdAsync(int id)
        {
            return await _context.Configuration.FindAsync(id);
        }

        public async Task UpdateConfigurationAsync(Configurations configurations)
        {
            _context.Configuration.Update(configurations);
            await _context.SaveChangesAsync();
        }
    }
}
