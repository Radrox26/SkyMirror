namespace SkyMirror.BusinessLogic.Dto.QuotationItem
{
    public class QuotationItemResponseDto
    {
        public int QuotationItemId { get; }
        public int QuotationId { get; }
        public int ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public QuotationItemResponseDto(int quotationItemId, int quotationId, int productId, string productName, int quantity, decimal price)
        {
            QuotationItemId = quotationItemId;
            QuotationId = quotationId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
