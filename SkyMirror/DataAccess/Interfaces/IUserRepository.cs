using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();   
        Task<User?> GetByIdAsync(int id);         
        Task<int> AddAsync(User user);           
        Task UpdateAsync(User user);             
        Task DeleteAsync(int id);                
        Task<User?> GetByEmailAsync(string email); 
    }
}
