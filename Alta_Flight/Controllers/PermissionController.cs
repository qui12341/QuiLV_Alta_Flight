using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alta_Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermission()
        {
            var groups = await _permissionService.GetAllPermissionAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> GetPermission(int id)
        {
            var groups = await _permissionService.GetPermissionByIdAsync(id);
            if (groups == null)
            {
                return NotFound();
            }
            return Ok(groups);
        }
        [HttpPost]
        public async Task<ActionResult<Permission>> CreatePermission(Permission permission)
        {
            await _permissionService.CreatePermissionAsync(permission);
            return CreatedAtAction(nameof(GetPermission), new { id = permission.Permission_Id }, permission);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, Permission permission)
        {
            if (id != permission.Permission_Id)
            {
                return BadRequest();
            }

            await _permissionService.UpdatePermissionAsync(permission);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            await _permissionService.DeletePermissionAsync(id);
            return NoContent();
        }
    }
}
