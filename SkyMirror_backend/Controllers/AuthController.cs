using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.User;
using SkyMirror.Security.Interfaces;

namespace SkyMirror_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDto request)
        {
            try
            {
                LoginUserResponseDto response = await _authService.LoginUserAsync(request);

                if(response.RefreshToken == null || response.RefreshTokenExpiry == null)
                {
                    throw new InvalidOperationException("Refresh token or expiry is null");
                }

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = response.RefreshTokenExpiry
                };

                Response.Cookies.Append("refreshToken", response.RefreshToken, cookieOptions);

                return Ok(new
                {
                    accessToken = response.AccessToken,
                    expiresAt = response.AccessTokenExpiresAt,
                    fullName = response.FullName,
                    email = response.Email,
                    roleName = response.RoleName
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {

                if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
                    return Unauthorized("Refresh token missing");

                if (string.IsNullOrEmpty(refreshToken))
                    return Unauthorized("Invalid refresh token");

                var response = await _authService.RefreshTokenAsync(refreshToken);

                if (response.RefreshToken == null)
                    throw new InvalidOperationException("Refresh token should not be null");

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = response.RefreshTokenExpiry
                };
                Response.Cookies.Append("refreshToken", response.RefreshToken, cookieOptions);

                return Ok(new
                {
                    accessToken = response.AccessToken,
                    accessTokenExpiry = response.AccessTokenExpiresAt,
                    fullName = response.FullName,
                    email = response.Email,
                    role = response.RoleName
                });

            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutUserRequestDto request)
        {
            try
            {
                await _authService.LogoutUserAsync(request);
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}
