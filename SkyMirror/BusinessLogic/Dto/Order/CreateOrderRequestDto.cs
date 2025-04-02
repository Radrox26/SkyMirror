using SkyMirror.BusinessLogic.Dto.Item;

namespace SkyMirror.BusinessLogic.Dto.Order
{
    public class CreateOrderRequestDto
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public List<CreateOrderItemRequestDto> OrderItems { get; set; } = new List<CreateOrderItemRequestDto>();
    }
}
