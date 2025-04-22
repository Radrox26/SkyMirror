using Microsoft.EntityFrameworkCore;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly SkyMirrorDbContext _context;

        public UserRoleRepository(SkyMirrorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int id)
        {
            return await _context.UserRoles.FindAsync(id);
        }

        public async Task<UserRole?> GetByNameAsync(string roleName)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }
    }
}
