using Microsoft.EntityFrameworkCore;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly SkyMirrorDbContext _context;

        public ProductCategoryRepository(SkyMirrorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }
    }
}
