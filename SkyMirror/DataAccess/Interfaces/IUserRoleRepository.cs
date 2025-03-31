using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole?> GetByIdAsync(int id);
        Task<UserRole?> GetByNameAsync(string roleName);
        Task<IEnumerable<UserRole>> GetAllAsync();
    }
}
