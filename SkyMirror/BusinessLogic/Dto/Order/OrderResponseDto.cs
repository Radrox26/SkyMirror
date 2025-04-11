
using SkyMirror.BusinessLogic.Dto.OrderItem;

namespace SkyMirror.BusinessLogic.Dto.Order
{
    public class OrderResponseDto
    {
        public int OrderId { get; }
        public int UserId { get; }
        public decimal TotalAmount { get; }
        public string Status { get; }
        public DateTime OrderDate { get; }
        public IReadOnlyList<OrderItemResponseDto> OrderItems { get; }

        public OrderResponseDto(int orderId, int userId, decimal totalAmount, string status, DateTime orderDate, List<OrderItemResponseDto> orderItems)
        {
            OrderId = orderId;
            UserId = userId;
            TotalAmount = totalAmount;
            Status = status;
            OrderDate = orderDate;
            OrderItems = orderItems.AsReadOnly();
        }
    }
}
