namespace SkyMirror.BusinessLogic.Dto.Lead
{
    public class UpdateLeadRequestDto
    {
        public int LeadId { get; set; }
        public string InquiryDetails { get; set; } = string.Empty;
        public string Status { get; set; } = "New";
    }
}
