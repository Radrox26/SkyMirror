namespace SkyMirror.BusinessLogic.Dto.Payment
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; }
        public int OrderId { get; }
        public decimal AmountPaid { get; }
        public string PaymentStatus { get; } = string.Empty;
        public DateTime PaymentDate { get; }

        public PaymentResponseDto(int paymentId, int orderId, decimal amountPaid, string paymentStatus, DateTime paymentDate)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            AmountPaid = amountPaid;
            PaymentStatus = paymentStatus;
            PaymentDate = paymentDate;
        }
    }
}
