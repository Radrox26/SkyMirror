namespace SkyMirror.BusinessLogic.Dto.Product
{
    public class CreateProductRequestDto
    {
        public string PanelName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int PowerInWatts { get; set; }
        public int StockQuantity { get; set; }
    }
}
