using Microsoft.EntityFrameworkCore;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Repository
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly SkyMirrorDbContext _context;

        public QuotationRepository(SkyMirrorDbContext context)
        {
            _context = context;
        }

        // 🔹 Get all quotations
        public async Task<IEnumerable<Quotation>> GetAllAsync()
        {
            return await _context.Quotations
                .Include(q => q.Lead) // Include lead details
                .Include(q => q.QuotationItems) // Include quotation items
                .ToListAsync();
        }

        // 🔹 Get quotation by ID
        public async Task<Quotation?> GetByIdAsync(int id)
        {
            return await _context.Quotations
                .Include(q => q.Lead)
                .Include(q => q.QuotationItems)
                .FirstOrDefaultAsync(q => q.QuotationId == id);
        }

        // 🔹 Get all quotations for a specific lead
        public async Task<IEnumerable<Quotation>> GetByLeadIdAsync(int leadId)
        {
            return await _context.Quotations
                .Where(q => q.LeadId == leadId)
                .Include(q => q.QuotationItems)
                .ToListAsync();
        }

        // 🔹 Add a new quotation & return its ID
        public async Task<int> AddAsync(Quotation quotation)
        {
            _context.Quotations.Add(quotation);
            await _context.SaveChangesAsync();
            return quotation.QuotationId;
        }

        // 🔹 Update quotation details
        public async Task UpdateAsync(Quotation quotation)
        {
            _context.Entry(quotation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // 🔹 Delete a quotation by ID
        public async Task DeleteAsync(int id)
        {
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation != null)
            {
                _context.Quotations.Remove(quotation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
