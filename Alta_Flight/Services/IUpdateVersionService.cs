using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IUpdateVersionService
    {
        Task<IEnumerable<UpdateVersions>> GetAllUpdateVersionAsync();
        Task<UpdateVersions> GetUpdateVersionByIdAsync(int id);
        Task CreateUpdateVersionAsync(UpdateVersions updateVersions);
        Task UpdateUpdateVersionAsync(UpdateVersions updateVersions);
        Task DeleteUpdateVersionAsync(int id);
    }
}
