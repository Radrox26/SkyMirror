using SkyMirror.BusinessLogic.Dto.User;

namespace SkyMirror.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(int userId);
        Task<int> RegisterUserAsync(CreateUserRequestDto request);
        Task UpdateUserAsync(int userId, UpdateUserRequestDto request);
        Task DeleteUserAsync(int userId);
    }
}
