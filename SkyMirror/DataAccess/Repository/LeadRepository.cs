using Microsoft.EntityFrameworkCore;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Repository
{
    public class LeadRepository : ILeadRepository
    {
        private readonly SkyMirrorDbContext _context;

        public LeadRepository(SkyMirrorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            return await _context.Leads.ToListAsync();
        }

        public async Task<Lead?> GetByIdAsync(int id)
        {
            return await _context.Leads.FirstOrDefaultAsync(l => l.LeadId == id);
        }

        public async Task<IEnumerable<Lead>> GetLeadsByUserIdAsync(int userId)
        {
            return await _context.Leads.Where(l => l.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(Lead lead)
        {
            await _context.Leads.AddAsync(lead);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lead lead)
        {
            _context.Entry(lead).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead != null)
            {
                _context.Leads.Remove(lead);
                await _context.SaveChangesAsync();
            }
        }
    }
}
