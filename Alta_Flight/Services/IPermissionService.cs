using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllPermissionAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task DeletePermissionAsync(int id);
    }
}
