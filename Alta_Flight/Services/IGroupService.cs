using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Groups>> GetAllGroupAsync();
        Task<Groups> GetGroupByIdAsync(int id);
        Task CreateGroupAsync(Groups groups);
        Task UpdateGroupAsync(Groups groups);
        Task DeleteGroupAsync(int id);
    }
}
