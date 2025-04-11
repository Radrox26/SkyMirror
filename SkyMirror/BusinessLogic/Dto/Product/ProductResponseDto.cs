using SkyMirror.BusinessLogic.Dto.ProductCategory;

namespace SkyMirror.BusinessLogic.Dto.Product
{
    public class ProductResponseDto
    {
        public int ProductId { get; }
        public string PanelName { get; }
        public string CategoryName { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int PowerInWatts { get; }
        public bool IsAvailable { get; }

        public ProductResponseDto(
            int productId,
            string panelName,
            string categoryName,
            string description,
            decimal price,
            int powerInWatts,
            int stockQuantity)
        {
            ProductId = productId;
            PanelName = panelName;
            CategoryName = categoryName;
            Description = description;
            Price = price;
            PowerInWatts = powerInWatts;
            IsAvailable = stockQuantity > 0;
        }
    }
}
