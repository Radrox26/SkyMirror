namespace SkyMirror.BusinessLogic.Dto.QuotationItem
{
    public class UpdateQuotationItemRequestDto
    {
        public int QuotationItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
