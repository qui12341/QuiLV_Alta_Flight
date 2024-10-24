using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;

namespace Alta_Flight.Services
{
    public class FlightDocumentListService : IFlightDocumentListService
    {
        private readonly AppDBContext _context;

        public FlightDocumentListService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateFlightDocListAsync(Flight_document_lists FlightDocLists)
        {
            await _context.flight_Document_List.AddAsync(FlightDocLists);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightDocListAsync(int id)
        {
            var flightDocLists = await _context.flight_Document_List.FindAsync(id);
            if (flightDocLists != null)
            {
                _context.flight_Document_List.Remove(flightDocLists);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Flight_document_lists>> GetAllFlightDocListAsync()
        {
            return await _context.flight_Document_List.ToListAsync();
        }

        public async Task<Flight_document_lists> GetFlightDocListByIdAsync(int id)
        {
            return await _context.flight_Document_List.FindAsync(id);
        }

        public async Task UpdateFlightDocListAsync(Flight_document_lists FlightDocLists)
        {
            _context.flight_Document_List.Update(FlightDocLists);
            await _context.SaveChangesAsync();
        }
    }
}
