using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.Quotation;
using SkyMirror.BusinessLogic.Interfaces;

namespace SkyMirror.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        // GET: api/Quotation
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuotationResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllQuotations()
        {
            try
            {
                var quotations = await _quotationService.GetAllQuotationsAsync();

                if (quotations == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving quotations.");

                if (!quotations.Any())
                    return NoContent();

                return Ok(quotations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving quotations: {ex.Message}");
            }
        }

        // GET: api/Quotation/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuotationResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetQuotationById(int id)
        {
            try
            {
                var quotation = await _quotationService.GetQuotationByIdAsync(id);
                if (quotation == null)
                    return NotFound($"Quotation with ID {id} not found.");

                return Ok(quotation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving quotation: {ex.Message}");
            }
        }

        // POST: api/Quotation
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateQuotation(CreateQuotationRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var quotationId = await _quotationService.CreateQuotationAsync(request);
                return CreatedAtAction(nameof(GetQuotationById), new { id = quotationId }, quotationId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating quotation: {ex.Message}");
            }
        }

        // PUT: api/Quotation/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateQuotation(int id, UpdateQuotationRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existing = await _quotationService.GetQuotationByIdAsync(id);
                if (existing == null)
                    return NotFound($"Quotation with ID {id} not found.");

                await _quotationService.UpdateQuotationAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating quotation: {ex.Message}");
            }
        }

        // DELETE: api/Quotation/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteQuotation(int id)
        {
            try
            {
                var existing = await _quotationService.GetQuotationByIdAsync(id);
                if (existing == null)
                    return NotFound($"Quotation with ID {id} not found.");

                await _quotationService.DeleteQuotationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting quotation: {ex.Message}");
            }
        }
    }
}
