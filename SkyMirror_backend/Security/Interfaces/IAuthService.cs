using SkyMirror.BusinessLogic.Dto.User;

namespace SkyMirror.Security.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUserResponseDto> LoginUserAsync(LoginUserRequestDto request);
        Task<LoginUserResponseDto> RefreshTokenAsync(string request);
        Task LogoutUserAsync(LogoutUserRequestDto request);
        Task ChangePasswordAsync(int userId, ChangePasswordRequestDto request);
    }
}
