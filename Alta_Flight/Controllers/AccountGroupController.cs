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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account_Groups>>> GetAccountGroup()
        {
            var acc_groups = await _accountGroupService.GetAllAccountGroupAsync();
            return Ok(acc_groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account_Groups>> GetAccountGroup(int id)
        {
            var acc_groups = await _accountGroupService.GetAccountGroupByIdAsync(id);
            if (acc_groups == null)
            {
                return NotFound();
            }
            return Ok(acc_groups);
        }
        [HttpPost]
        public async Task<ActionResult<Account_Groups>> CreateGroup(Account_Groups acc_groups)
        {
            await _accountGroupService.CreateAccountGroupAsync(acc_groups);
            return CreatedAtAction(nameof(GetAccountGroup), new { id = acc_groups.Id }, acc_groups);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, Account_Groups acc_groups)
        {
            if (id != acc_groups.Id)
            {
                return BadRequest();
            }

            await _accountGroupService.UpdateAccountGroupAsync(acc_groups);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _accountGroupService.DeleteAccountGroupAsync(id);
            return NoContent();
        }

    }
}
