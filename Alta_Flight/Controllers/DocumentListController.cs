using Alta_Flight.Model;
using Alta_Flight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alta_Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentListController : ControllerBase
    {
        private readonly IDocumentListService _DocListService;
        public DocumentListController(IDocumentListService DocListService)
        {
            _DocListService = DocListService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document_Lists>>> GetDocumentList()
        {
            var DocList = await _DocListService.GetAllDocListAsync();
            return Ok(DocList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document_Lists>> GetDocumentList(int id)
        {
            var DocList = await _DocListService.GetDocListByIdAsync(id);
            if (DocList == null)
            {
                return NotFound();
            }
            return Ok(DocList);
        }
        [HttpPost]
        public async Task<ActionResult<Document_Lists>> CreateDocumentList(Document_Lists DocList)
        {
            await _DocListService.CreateDocListAsync(DocList);
            return CreatedAtAction(nameof(GetDocumentList), new { id = DocList.document_list_id }, DocList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocumentList(int id, Document_Lists DocList)
        {
            if (id != DocList.document_list_id)
            {
                return BadRequest();
            }

            await _DocListService.UpdateDocListAsync(DocList);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentList(int id)
        {
            await _DocListService.DeleteDocListAsync(id);
            return NoContent();
        }
    }
}
