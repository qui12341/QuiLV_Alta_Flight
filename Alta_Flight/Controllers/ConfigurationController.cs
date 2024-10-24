using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Alta_Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configurations>>> GetConfiguration()
        {
            var configurations = await _configurationService.GetAllConfigurationAsync();
            return Ok(configurations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Configurations>> GetConfiguration(int id)
        {
            var configurations = await _configurationService.GetConfigurationByIdAsync(id);
            if (configurations == null)
            {
                return NotFound();
            }
            return Ok(configurations);
        }

        [HttpPost]
        public async Task<ActionResult<Configurations>> CreateConfiguration(Configurations configurations)
        {
            await _configurationService.CreateConfigurationAsync(configurations);
            return CreatedAtAction(nameof(GetConfiguration), new { id = configurations.configuration_ID }, configurations);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfiguration(int id, Configurations configurations)
        {
            if (id != configurations.configuration_ID)
            {
                return BadRequest();
            }

            await _configurationService.UpdateConfigurationAsync(configurations);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfigurations(int id)
        {
            await _configurationService.DeleteConfigurationAsync(id);
            return NoContent();
        }
    }
}
