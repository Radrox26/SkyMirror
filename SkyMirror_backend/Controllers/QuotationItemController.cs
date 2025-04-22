using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.QuotationItem;
using SkyMirror.BusinessLogic.Interfaces;

namespace SkyMirror.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotationItemController : ControllerBase
    {
        private readonly IQuotationItemService _quotationItemService;

        public QuotationItemController(IQuotationItemService quotationItemService)
        {
            _quotationItemService = quotationItemService;
        }

        // GET: api/QuotationItem/quotation/5
        [HttpGet("quotation/{quotationId}")]
        [ProducesResponseType(typeof(IEnumerable<QuotationItemResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetItemsByQuotationId(int quotationId)
        {
            try
            {
                var items = await _quotationItemService.GetItemsByQuotationIdAsync(quotationId);
                if (items == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving quotation items.");

                if (!items.Any())
                    return NoContent();

                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception: {ex.Message}");
            }
        }

        // GET: api/QuotationItem/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuotationItemResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _quotationItemService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"Quotation item with ID {id} not found.");

            return Ok(item);
        }

        // POST: api/QuotationItem
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateQuotationItemRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _quotationItemService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT: api/QuotationItem/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateQuotationItemRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _quotationItemService.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Quotation item with ID {id} not found.");

            await _quotationItemService.UpdateAsync(id, request);
            return NoContent();
        }

        // DELETE: api/QuotationItem/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _quotationItemService.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Quotation item with ID {id} not found.");

            await _quotationItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
