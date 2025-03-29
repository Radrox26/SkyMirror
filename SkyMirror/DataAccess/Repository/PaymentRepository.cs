using Microsoft.EntityFrameworkCore;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SkyMirrorDbContext _context;

        public PaymentRepository(SkyMirrorDbContext context)
        {
            _context = context;
        }

        // 🔹 Get all payments
        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .Include(p => p.Order) // Include order details
                .ToListAsync();
        }

        // 🔹 Get payment by ID
        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.PaymentId == id);
        }

        // 🔹 Get payment for a specific order
        public async Task<Payment?> GetByOrderIdAsync(int orderId)
        {
            return await _context.Payments
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.OrderId == orderId);
        }

        // 🔹 Add a new payment & return its ID
        public async Task<int> AddAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment.PaymentId;
        }

        // 🔹 Update payment details
        public async Task UpdateAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // 🔹 Delete a payment by ID
        public async Task DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
