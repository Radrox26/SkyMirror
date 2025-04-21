using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetAllAsync();
        Task<Lead?> GetByIdAsync(int id);
        Task<int> AddAsync(Lead lead);
        Task UpdateAsync(Lead lead);
        Task DeleteAsync(int id);
        Task<IEnumerable<Lead>> GetLeadsByUserIdAsync(int userId);
    }
}
