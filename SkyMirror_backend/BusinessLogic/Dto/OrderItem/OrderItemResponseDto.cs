namespace SkyMirror.BusinessLogic.Dto.OrderItem
{
    public class OrderItemResponseDto
    {
        public int OrderItemId { get; }
        public int OrderId { get; }
        public int ProductId { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public OrderItemResponseDto(int orderItemId, int orderId, int productId, int quantity, decimal price)
        {
            OrderItemId = orderItemId;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}
