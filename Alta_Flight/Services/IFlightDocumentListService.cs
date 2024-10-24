using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IFlightDocumentListService
    {
        Task<IEnumerable<Flight_document_lists>> GetAllFlightDocListAsync();
        Task<Flight_document_lists> GetFlightDocListByIdAsync(int id);
        Task CreateFlightDocListAsync(Flight_document_lists FlightDocLists);
        Task UpdateFlightDocListAsync(Flight_document_lists FlightDocLists);
        Task DeleteFlightDocListAsync(int id);
    }
}
