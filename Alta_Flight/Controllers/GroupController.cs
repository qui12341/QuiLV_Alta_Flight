using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alta_Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groups>>> GetGroup()
        {
            var groups = await _groupService.GetAllGroupAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Groups>> GetGroup(int id)
        {
            var groups = await _groupService.GetGroupByIdAsync(id);
            if (groups == null)
            {
                return NotFound();
            }
            return Ok(groups);
        }
        [HttpPost]
        public async Task<ActionResult<Groups>> CreateGroup(Groups groups)
        {
            await _groupService.CreateGroupAsync(groups);
            return CreatedAtAction(nameof(GetGroup), new { id = groups.group_id }, groups);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, Groups groups)
        {
            if (id != groups.group_id)
            {
                return BadRequest();
            }

            await _groupService.UpdateGroupAsync(groups);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _groupService.DeleteGroupAsync(id);
            return NoContent();
        }
    }
}
