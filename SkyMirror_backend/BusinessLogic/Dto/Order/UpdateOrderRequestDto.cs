using SkyMirror.BusinessLogic.Dto.OrderItem;

namespace SkyMirror.BusinessLogic.Dto.Order
{
    public class UpdateOrderRequestDto
    {
        public decimal TotalAmount { get; set; } // Updated total amount if needed

        public string Status { get; set; } = string.Empty; // New order status like "Shipped", "Delivered", etc.

        public List<UpdateOrderItemRequestDto>? OrderItems { get; set; } // Optional: list of order items to update

    }
}
