using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.Payment;
using SkyMirror.BusinessLogic.Interfaces;

namespace SkyMirror.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/Payment/order/5
        [HttpGet("order/{orderId}")]
        [ProducesResponseType(typeof(PaymentResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var payment = await _paymentService.GetByOrderIdAsync(orderId);
            if (payment == null)
                return NotFound($"No payment found for order ID {orderId}");

            return Ok(payment);
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PaymentResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null)
                return NotFound($"Payment with ID {id} not found.");

            return Ok(payment);
        }

        // POST: api/Payment
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreatePaymentRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _paymentService.CreatePaymentAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdatePaymentRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _paymentService.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Payment with ID {id} not found.");

            await _paymentService.UpdatePaymentAsync(id, request);
            return NoContent();
        }
    }
}
