using SkyMirror.BusinessLogic.Dto.User;

namespace SkyMirror.Security.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUserResponseDto> LoginUserAsync(LoginUserRequestDto request);
        Task<LoginUserResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
        Task LogoutUserAsync(LogoutUserRequestDto request);
        Task ChangePasswordAsync(int userId, ChangePasswordRequestDto request);
    }
}
