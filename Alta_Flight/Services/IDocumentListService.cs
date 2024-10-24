using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IDocumentListService
    {
        Task<IEnumerable<Document_Lists>> GetAllDocListAsync();
        Task<Document_Lists> GetDocListByIdAsync(int id);
        Task CreateDocListAsync(Document_Lists DocLists);
        Task UpdateDocListAsync(Document_Lists DocLists);
        Task DeleteDocListAsync(int id);
    }
}
