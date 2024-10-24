using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alta_Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightDocListController : ControllerBase
    {
        private readonly IFlightDocumentListService _flightDocListService;
        public FlightDocListController(IFlightDocumentListService flightDocListService)
        {
            _flightDocListService = flightDocListService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight_document_lists>>> GetFlightDoc()
        {
            var flightDoc = await _flightDocListService.GetAllFlightDocListAsync();
            return Ok(flightDoc);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight_document_lists>> GetFlightDoc(int id)
        {
            var flightDocList = await _flightDocListService.GetFlightDocListByIdAsync(id);
            if (flightDocList == null)
            {
                return NotFound();
            }
            return Ok(flightDocList);
        }
        [HttpPost]
        public async Task<ActionResult<Flight_document_lists>> CreateFlight(Flight_document_lists flightDoc)
        {
            await _flightDocListService.CreateFlightDocListAsync(flightDoc);
            return CreatedAtAction(nameof(GetFlightDoc), new { id = flightDoc.flight_document_lists }, flightDoc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, Flight_document_lists flightDoc)
        {
            if (id != flightDoc.flight_document_lists)
            {
                return BadRequest();
            }

            await _flightDocListService.UpdateFlightDocListAsync(flightDoc);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _flightDocListService.DeleteFlightDocListAsync(id);
            return NoContent();
        }
    }
}
