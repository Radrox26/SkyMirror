namespace SkyMirror.BusinessLogic.Dto.Payment
{
    public class CreatePaymentRequestDto
    {
        public int OrderId { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
    }
}
