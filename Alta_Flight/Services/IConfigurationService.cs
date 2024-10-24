using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IConfigurationService
    {
        Task<IEnumerable<Configurations>> GetAllConfigurationAsync();
        Task<Configurations> GetConfigurationByIdAsync(int id);
        Task CreateConfigurationAsync(Configurations configurations);
        Task UpdateConfigurationAsync(Configurations configurations);
        Task DeleteConfigurationAsync(int id);
    }
}
