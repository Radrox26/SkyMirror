using SkyMirror.BusinessLogic.Dto.Payment;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Entities;

namespace SkyMirror.BusinessLogic.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentResponseDto> GetByOrderIdAsync(int orderId)
        {
            var payment = await _paymentRepository.GetByOrderIdAsync(orderId);
            if (payment == null)
                throw new KeyNotFoundException($"Payment with OrderId {orderId} not found.");

            return new PaymentResponseDto
            (
                payment.PaymentId,
                payment.OrderId,
                payment.AmountPaid,
                payment.PaymentStatus,
                payment.PaymentDate
            );
        }

        public async Task<int> CreatePaymentAsync(CreatePaymentRequestDto request)
        {
            var payment = new Payment
            {
                OrderId = request.OrderId,
                AmountPaid = request.AmountPaid,
                PaymentStatus = request.PaymentStatus
            };

            return await _paymentRepository.AddAsync(payment);
        }

        public async Task UpdatePaymentAsync(int paymentId, UpdatePaymentRequestDto request)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null)
                throw new KeyNotFoundException($"Payment with ID {paymentId} not found.");

            payment.AmountPaid = request.AmountPaid;
            payment.PaymentStatus = request.PaymentStatus;

            await _paymentRepository.UpdateAsync(payment);
        }

        public async Task<PaymentResponseDto> GetByIdAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);

            if (payment == null)
                throw new KeyNotFoundException($"Payment with ID {paymentId} not found.");

            var response = new PaymentResponseDto
            (
                payment.PaymentId,
                payment.OrderId,
                payment.AmountPaid,
                payment.PaymentStatus,
                payment.PaymentDate
            );

            return response;
        }
    }
}
