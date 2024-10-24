using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;

namespace Alta_Flight.Services
{
    public class DocumentListService : IDocumentListService
    {
        private readonly AppDBContext _context;

        public DocumentListService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateDocListAsync(Document_Lists DocLists)
        {
            await _context.Document_List.AddAsync(DocLists);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocListAsync(int id)
        {
            var DocLists = await _context.Document_List.FindAsync(id);
            if (DocLists != null)
            {
                _context.Document_List.Remove(DocLists);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Document_Lists>> GetAllDocListAsync()
        {
            return await _context.Document_List.ToListAsync();
        }

        public async Task<Document_Lists> GetDocListByIdAsync(int id)
        {
            return await _context.Document_List.FindAsync(id);
        }

        public async Task UpdateDocListAsync(Document_Lists DocLists)
        {
            _context.Document_List.Update(DocLists);
            await _context.SaveChangesAsync();
        }
    }
}
