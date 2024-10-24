using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IFlightService
    {
        Task<IEnumerable<Flights>> GetAllFlightAsync();
        Task<Flights> GetFlightsByIdAsync(int id);
        Task CreateFlightAsync(Flights flights);
        Task UpdateFlightAsync(Flights flights);
        Task DeleteFlightAsync(int id);
    }
}
