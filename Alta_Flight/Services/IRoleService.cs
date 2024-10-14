using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Roles>> GetAllRolesAsync();
        Task<Roles> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Roles role);
        Task UpdateRoleAsync(Roles role);
        Task DeleteRoleAsync(int id);
    }
}
