namespace SkyMirror.BusinessLogic.Dto.Quotation
{
    public class QuotationResponseDto
    {
        public int QuotationId { get; }
        public int LeadId { get; }
        public int SalesManagerId { get; }
        public decimal TotalAmount { get; }
        public string Status { get; }
        public DateTime CreatedAt { get; }

        public QuotationResponseDto(int quotationId, int leadId, int salesManagerId, decimal totalAmount, string status, DateTime createdAt)
        {
            QuotationId = quotationId;
            LeadId = leadId;
            SalesManagerId = salesManagerId;
            TotalAmount = totalAmount;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
