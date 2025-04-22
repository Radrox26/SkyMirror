namespace SkyMirror.BusinessLogic.Dto.ProductCategory
{
    public class ProductCategoryResponseDto
    {
        public string CategoryName { get; }

        public ProductCategoryResponseDto(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
