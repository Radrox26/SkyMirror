using Microsoft.EntityFrameworkCore;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Repository
{
    public class QuotationItemRepository : IQuotationItemRepository
    {
        private readonly SkyMirrorDbContext _context;

        public QuotationItemRepository(SkyMirrorDbContext context)
        {
            _context = context;
        }

        // 🔹 Get all quotation items
        public async Task<IEnumerable<QuotationItem>> GetAllAsync()
        {
            return await _context.QuotationItems
                .Include(qi => qi.Quotation) // Include quotation details
                .Include(qi => qi.Product) // Include product details
                .ToListAsync();
        }

        // 🔹 Get quotation item by ID
        public async Task<QuotationItem?> GetByIdAsync(int id)
        {
            return await _context.QuotationItems
                .Include(qi => qi.Quotation)
                .Include(qi => qi.Product)
                .FirstOrDefaultAsync(qi => qi.QuotationItemId == id);
        }

        // 🔹 Get all quotation items for a specific quotation
        public async Task<IEnumerable<QuotationItem>> GetByQuotationIdAsync(int quotationId)
        {
            return await _context.QuotationItems
                .Where(qi => qi.QuotationId == quotationId)
                .Include(qi => qi.Product)
                .ToListAsync();
        }

        // 🔹 Add a new quotation item & return its ID
        public async Task<int> AddAsync(QuotationItem quotationItem)
        {
            _context.QuotationItems.Add(quotationItem);
            await _context.SaveChangesAsync();
            return quotationItem.QuotationItemId;
        }

        // 🔹 Update quotation item details
        public async Task UpdateAsync(QuotationItem quotationItem)
        {
            _context.Entry(quotationItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // 🔹 Delete a quotation item by ID
        public async Task DeleteAsync(int id)
        {
            var quotationItem = await _context.QuotationItems.FindAsync(id);
            if (quotationItem != null)
            {
                _context.QuotationItems.Remove(quotationItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
