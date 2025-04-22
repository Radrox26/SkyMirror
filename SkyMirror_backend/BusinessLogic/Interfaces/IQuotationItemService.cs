using SkyMirror.BusinessLogic.Dto.QuotationItem;

namespace SkyMirror.BusinessLogic.Interfaces
{
    public interface IQuotationItemService
    {
        Task<IEnumerable<QuotationItemResponseDto>> GetItemsByQuotationIdAsync(int quotationId);
        Task<QuotationItemResponseDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateQuotationItemRequestDto request);
        Task UpdateAsync(int id, UpdateQuotationItemRequestDto request);
        Task DeleteAsync(int id);
    }
}
