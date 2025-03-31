using SkyMirror.BusinessLogic.Dto.ProductCategory;

namespace SkyMirror.BusinessLogic.Dto.Product
{
    public class ProductResponseDto
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public ProductCategoryResponseDto Category { get; }

        public ProductResponseDto(int id, string name, string description, decimal price, ProductCategoryResponseDto category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
