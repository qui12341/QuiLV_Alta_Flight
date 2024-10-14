using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alta_Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountGroupController : ControllerBase
    {
        private readonly IAccountGroupService _accountGroupService;
        public AccountGroupController(IAccountGroupService accountGroupService)
        {
            _accountGroupService = accountGroupService;
        }
        // GET: api/accountgroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account_Groups>>> GetAllAccountGroups()
        {
            var accountGroups = await _accountGroupService.GetAllAccountGroupsAsync();
            return Ok(accountGroups);
        }

        // GET: api/accountgroups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Account_Groups>> GetAccountGroupById(int id)
        {
            var accountGroup = await _accountGroupService.GetAccountGroupByIdAsync(id);
            if (accountGroup == null)
            {
                return NotFound();
            }
            return Ok(accountGroup);
        }

        // POST: api/accountgroups
        [HttpPost]
        public async Task<ActionResult> AddAccountToGroup(int accountId, int groupId)
        {
            await _accountGroupService.AddAccountToGroupAsync(accountId, groupId);
            return Ok();
        }

        // PUT: api/accountgroups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountGroup(int id, int groupId)
        {
            await _accountGroupService.UpdateAccountGroupAsync(id, groupId);
            return NoContent();
        }

        // DELETE: api/accountgroups/{accountId}/{groupId}
        [HttpDelete("{accountId}/{groupId}")]
        public async Task<IActionResult> RemoveAccountFromGroup(int accountId, int groupId)
        {
            await _accountGroupService.RemoveAccountFromGroupAsync(accountId, groupId);
            return NoContent();
        }

    }
}
