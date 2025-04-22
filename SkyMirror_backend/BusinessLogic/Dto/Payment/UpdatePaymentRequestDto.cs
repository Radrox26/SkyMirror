namespace SkyMirror.BusinessLogic.Dto.Payment
{
    public class UpdatePaymentRequestDto
    {
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
    }
}
