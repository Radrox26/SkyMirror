using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.Order;
using SkyMirror.BusinessLogic.Interfaces;

namespace SkyMirror.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            if (orders == null || !orders.Any())
                return NoContent();

            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound($"Order with ID {id} not found.");

            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateOrderRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderId = await _orderService.CreateOrderAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = orderId }, orderId);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateOrderRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingOrder = await _orderService.GetOrderByIdAsync(id);
            if (existingOrder == null)
                return NotFound($"Order with ID {id} not found.");

            await _orderService.UpdateOrderAsync(id, request);
            return NoContent();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existingOrder = await _orderService.GetOrderByIdAsync(id);
            if (existingOrder == null)
                return NotFound($"Order with ID {id} not found.");

            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
