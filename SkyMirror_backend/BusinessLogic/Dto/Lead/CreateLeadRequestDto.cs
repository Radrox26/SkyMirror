namespace SkyMirror.BusinessLogic.Dto.Lead
{
    public class CreateLeadRequestDto
    {
        public int UserId { get; set; }
        public string InquiryDetails { get; set; } = string.Empty;
        public string Status { get; set; } = "New";
    }
}
