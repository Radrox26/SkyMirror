using SkyMirror.BusinessLogic.Dto.QuotationItem;

namespace SkyMirror.BusinessLogic.Dto.Quotation
{
    public class UpdateQuotationRequestDto
    {
        public int QuotationId { get; set; }
        public int LeadId { get; set; }
        public int SalesManagerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public List<UpdateQuotationItemRequestDto> QuotationItems { get; set; } = new();

    }
}
