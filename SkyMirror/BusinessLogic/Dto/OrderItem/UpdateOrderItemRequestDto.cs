﻿namespace SkyMirror.BusinessLogic.Dto.OrderItem
{
    public class UpdateOrderItemRequestDto
    {
        public int OrderItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
