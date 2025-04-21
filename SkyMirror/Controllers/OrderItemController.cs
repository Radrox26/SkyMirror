using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.Order;
using SkyMirror.BusinessLogic.Dto.OrderItem;
using SkyMirror.BusinessLogic.Interfaces;

namespace SkyMirror.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // GET: api/OrderItem/order/5
        [HttpGet("order/{orderId}")]
        [ProducesResponseType(typeof(IEnumerable<OrderItemResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetItemsByOrderId(int orderId)
        {
            var items = await _orderItemService.GetItemsByOrderIdAsync(orderId);
            if (items == null || !items.Any())
                return NoContent();

            return Ok(items);
        }

        // GET: api/OrderItem/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderItemResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _orderItemService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"Order item with ID {id} not found.");

            return Ok(item);
        }

        // POST: api/OrderItem
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateOrderItemRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _orderItemService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
        }

        // PUT: api/OrderItem/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateOrderItemRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingItem = await _orderItemService.GetByIdAsync(id);
            if (existingItem == null)
                return NotFound($"Order item with ID {id} not found.");

            await _orderItemService.UpdateAsync(id, request);
            return NoContent();
        }

        // DELETE: api/OrderItem/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existingItem = await _orderItemService.GetByIdAsync(id);
            if (existingItem == null)
                return NotFound($"Order item with ID {id} not found.");

            await _orderItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
