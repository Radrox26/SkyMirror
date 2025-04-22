namespace SkyMirror.BusinessLogic.Dto.QuotationItem
{
    public class CreateQuotationItemRequestDto
    {
        public int QuotationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
