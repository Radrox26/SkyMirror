using SkyMirror.BusinessLogic.Dto.Product;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Entities;

namespace SkyMirror.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            List<ProductResponseDto> result = new List<ProductResponseDto>();

            foreach (var product in products)
            {
                var category = await _productCategoryRepository.GetByIdAsync(product.CategoryId);
                string categoryName = category?.Name ?? "";

                result.Add(new ProductResponseDto(
                    product.ProductId,
                    product.PanelName,
                    categoryName,
                    product.Description,
                    product.Price,
                    product.PowerInWatts,
                    product.StockQuantity
                    ));
            }

            return result;
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if(product == null)
                throw new KeyNotFoundException("Product not found");

            var category = await _productCategoryRepository.GetByIdAsync(product.CategoryId);
            string categoryName = category?.Name ?? "";

            return new ProductResponseDto(
                product.ProductId,
                product.PanelName,
                categoryName,
                product.Description,
                product.Price,
                product.PowerInWatts,
                product.StockQuantity
            );
        }

        public async Task<int> CreateProductAsync(CreateProductRequestDto request)
        {
            var product = new Product
            {
                PanelName = request.PanelName,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Price = request.Price,
                PowerInWatts = request.PowerInWatts,
                StockQuantity = request.StockQuantity
            };

            return await _productRepository.AddAsync(product);
        }

        public Task DeleteProductAsync(int id)
        {
            var product = _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found");

            return _productRepository.DeleteAsync(id);
        }


        public async Task UpdateProductAsync(int id, UpdateProductRequestDto request)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found");

            product.PanelName = request.PanelName;
            product.CategoryId = request.CategoryId;
            product.Description = request.Description;
            product.Price = request.Price;
            product.PowerInWatts = request.PowerInWatts;
            product.StockQuantity = request.StockQuantity;

            await _productRepository.UpdateAsync(product);
        }
    }
}
