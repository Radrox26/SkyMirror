using SkyMirror.BusinessLogic.Dto.Order;
using SkyMirror.BusinessLogic.Dto.OrderItem;

namespace SkyMirror.BusinessLogic.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemResponseDto>> GetAllAsync();
        Task<OrderItemResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<OrderItemResponseDto>?> GetItemsByOrderIdAsync(int id);
        Task<int> CreateAsync(CreateOrderItemRequestDto request);
        Task UpdateAsync(int id, UpdateOrderItemRequestDto request);
        Task DeleteAsync(int id);
    }
}
