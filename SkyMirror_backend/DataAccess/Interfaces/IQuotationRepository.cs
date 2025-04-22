using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Interfaces
{
    public interface IQuotationRepository
    {
        Task<IEnumerable<Quotation>> GetAllAsync();
        Task<Quotation?> GetByIdAsync(int id);
        Task<IEnumerable<Quotation>> GetByLeadIdAsync(int leadId);
        Task<int> AddAsync(Quotation quotation);
        Task UpdateAsync(Quotation quotation);
        Task DeleteAsync(int id);
    }
}
