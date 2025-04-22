using Microsoft.EntityFrameworkCore;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SkyMirrorDbContext _context;

        public OrderRepository(SkyMirrorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersWithItemsAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<int> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.OrderId;
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
