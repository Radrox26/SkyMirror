using SkyMirror.BusinessLogic.Dto.User;
using System.Security.Claims;

namespace SkyMirror.CommonUtilities.Interface
{
    public interface IJwtTokenService
    {
        string GenerateToken(LoginUserResponseDto user);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
