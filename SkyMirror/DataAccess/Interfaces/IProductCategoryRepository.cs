using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory?> GetByIdAsync(int id);
    }
}
