using Alta_Flight.Data;
using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Alta_Flight.Services
{
    public class FlightService : IFlightService
    {
        private readonly AppDBContext _context;

        public FlightService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateFlightAsync(Flights flights)
        {
            await _context.Flight.AddAsync(flights);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            if (flight != null)
            {
                _context.Flight.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Flights>> GetAllFlightAsync()
        {
            return await _context.Flight.ToListAsync();

        }

        public async Task<Flights> GetFlightsByIdAsync(int id)
        {
            return await _context.Flight.FindAsync(id);

        }

        public async Task UpdateFlightAsync(Flights flights)
        {
            _context.Flight.Update(flights);
            await _context.SaveChangesAsync();
        }
    }
}
