using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Interfaces
{
    public interface IQuotationItemRepository
    {
        Task<IEnumerable<QuotationItem>> GetAllAsync();
        Task<QuotationItem?> GetByIdAsync(int id);
        Task<IEnumerable<QuotationItem>> GetByQuotationIdAsync(int quotationId);
        Task<int> AddAsync(QuotationItem quotationItem);
        Task UpdateAsync(QuotationItem quotationItem);
        Task DeleteAsync(int id);
    }
}
