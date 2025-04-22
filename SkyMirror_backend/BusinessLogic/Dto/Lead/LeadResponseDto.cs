namespace SkyMirror.BusinessLogic.Dto.Lead
{
    public class LeadResponseDto
    {
        public int LeadId { get; }
        public int UserId { get; }
        public string InquiryDetails { get; }
        public string Status { get; }
        public DateTime CreatedAt { get; }

        public LeadResponseDto(int leadId, int userId, string inquiryDetails, string status, DateTime createdAt)
        {
            LeadId = leadId;
            UserId = userId;
            InquiryDetails = inquiryDetails;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
