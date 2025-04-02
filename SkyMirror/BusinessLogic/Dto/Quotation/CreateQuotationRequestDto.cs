namespace SkyMirror.BusinessLogic.Dto.Quotation
{
    public class CreateQuotationRequestDto
    {
        public int QuotationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
