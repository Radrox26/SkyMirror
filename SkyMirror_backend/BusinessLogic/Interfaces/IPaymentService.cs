using SkyMirror.BusinessLogic.Dto.Payment;

namespace SkyMirror.BusinessLogic.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> GetByOrderIdAsync(int orderId);
        Task<PaymentResponseDto> GetByIdAsync(int orderId);
        Task<int> CreatePaymentAsync(CreatePaymentRequestDto request);
        Task UpdatePaymentAsync(int paymentId, UpdatePaymentRequestDto request);
    }
}
