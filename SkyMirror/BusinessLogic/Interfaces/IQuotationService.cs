using SkyMirror.BusinessLogic.Dto.Quotation;

namespace SkyMirror.BusinessLogic.Interfaces
{
    public interface IQuotationService
    {
        Task<IEnumerable<QuotationResponseDto>> GetAllQuotationsAsync();
        Task<QuotationResponseDto> GetQuotationByIdAsync(int id);
        Task<IEnumerable<QuotationResponseDto>> GetQuotationsByLeadIdAsync(int leadId);
        Task<int> CreateQuotationAsync(CreateQuotationRequestDto request);
        Task UpdateQuotationAsync(int id, UpdateQuotationRequestDto request);
        Task DeleteQuotationAsync(int id);
    }
}
