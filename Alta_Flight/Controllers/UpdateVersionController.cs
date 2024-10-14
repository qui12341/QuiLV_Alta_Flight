using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alta_Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateVersionController : ControllerBase
    {
        private readonly IUpdateVersionService _updateVersionService;
        public UpdateVersionController(IUpdateVersionService updateVersionService)
        {
            _updateVersionService = updateVersionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateVersions>>> GetUpdateVersion()
        {
            var roles = await _updateVersionService.GetAllUpdateVersionAsync();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UpdateVersions>> GetUpdateVersion(int id)
        {
            var updateVersions = await _updateVersionService.GetUpdateVersionByIdAsync(id);
            if (updateVersions == null)
            {
                return NotFound();
            }
            return Ok(updateVersions);
        }
        [HttpPost]
        public async Task<ActionResult<UpdateVersions>> CreateUpdateVersion(UpdateVersions updateVersions)
        {
            await _updateVersionService.CreateUpdateVersionAsync(updateVersions);
            return CreatedAtAction(nameof(GetUpdateVersion), new { id = updateVersions.Update_Version_ID }, updateVersions);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVersion(int id, UpdateVersions updateVersions)
        {
            if (id != updateVersions.Update_Version_ID)
            {
                return BadRequest();
            }

            await _updateVersionService.UpdateUpdateVersionAsync(updateVersions);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUpdateVersion(int id)
        {
            await _updateVersionService.DeleteUpdateVersionAsync(id);
            return NoContent();
        }
    }
}
