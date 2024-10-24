using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alta_Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flights>>> GetFlight()
        {
            var groups = await _flightService.GetAllFlightAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flights>> GetFlight(int id)
        {
            var groups = await _flightService.GetFlightsByIdAsync(id);
            if (groups == null)
            {
                return NotFound();
            }
            return Ok(groups);
        }
        [HttpPost]
        public async Task<ActionResult<Flights>> CreateFlight(Flights flights)
        {
            await _flightService.CreateFlightAsync(flights);
            return CreatedAtAction(nameof(GetFlight), new { id = flights.flight_ID }, flights);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, Flights flights)
        {
            if (id != flights.flight_ID)
            {
                return BadRequest();
            }

            await _flightService.UpdateFlightAsync(flights);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _flightService.DeleteFlightAsync(id);
            return NoContent();
        }
    }
}
