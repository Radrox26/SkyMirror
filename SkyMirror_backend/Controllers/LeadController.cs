using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.Lead;
using SkyMirror.BusinessLogic.Interfaces;

namespace SkyMirror.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        // GET: api/Lead
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LeadResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllLeads()
        {
            try
            {
                var leads = await _leadService.GetAllLeadsAsync();
                if (leads == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving leads.");

                if (!leads.Any())
                    return NoContent();

                return Ok(leads);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception: {ex.Message}");
            }
        }

        // GET: api/Lead/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LeadResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLeadById(int id)
        {
            try
            {
                var lead = await _leadService.GetLeadByIdAsync(id);
                if (lead == null)
                    return NotFound($"Lead with ID {id} not found.");

                return Ok(lead);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving lead: {ex.Message}");
            }
        }

        // POST: api/Lead
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLead(CreateLeadRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var leadId = await _leadService.CreateLeadAsync(request);
                return CreatedAtAction(nameof(GetLeadById), new { id = leadId }, leadId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating lead: {ex.Message}");
            }
        }

        // PUT: api/Lead/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLead(int id, UpdateLeadRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingLead = await _leadService.GetLeadByIdAsync(id);
                if (existingLead == null)
                    return NotFound($"Lead with ID {id} not found.");

                await _leadService.UpdateLeadStatusAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating lead: {ex.Message}");
            }
        }

        // DELETE: api/Lead/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLead(int id)
        {
            try
            {
                var existingLead = await _leadService.GetLeadByIdAsync(id);
                if (existingLead == null)
                    return NotFound($"Lead with ID {id} not found.");

                await _leadService.DeleteLeadAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting lead: {ex.Message}");
            }
        }
    }
}
