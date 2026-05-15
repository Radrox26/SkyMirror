using SkyMirror.BusinessLogic.Dto.User;
using System.Security.Claims;

namespace SkyMirror.CommonUtilities.Interface
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(LoginUserResponseDto user);
        string GenerateRefreshToken();
    }
}
