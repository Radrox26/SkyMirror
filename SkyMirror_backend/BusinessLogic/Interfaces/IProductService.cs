using SkyMirror.BusinessLogic.Dto.Product;

namespace SkyMirror.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task<int> CreateProductAsync(CreateProductRequestDto request);
        Task UpdateProductAsync(int id, UpdateProductRequestDto request);
        Task DeleteProductAsync(int id);
    }
}
