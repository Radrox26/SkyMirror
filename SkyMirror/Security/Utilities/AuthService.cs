using System;
using System.Threading.Tasks;
using SkyMirror.BusinessLogic.Dto.User;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Security.Interfaces;
using SkyMirror.Entities;
using SkyMirror.CommonUtilities.Interface;

namespace SkyMirror.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginUserResponseDto> LoginUserAsync(LoginUserRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            var userRole = await _userRoleRepository.GetByIdAsync(user.UserRoleId)
                         ?? throw new InvalidOperationException("User role not found");

            var tokenExpiry = DateTime.UtcNow.AddHours(1);

            // Create a temporary response DTO (without token)
            var userResponse = new LoginUserResponseDto("", tokenExpiry, user.FullName, user.Email, userRole.RoleName);

            // Now generate the token using the response DTO
            var token = _jwtTokenService.GenerateToken(userResponse);

            // Return the updated response DTO with the generated token
            return new LoginUserResponseDto(token, tokenExpiry, user.FullName, user.Email, userRole.RoleName);
        }


        public async Task<LoginUserResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(request.RefreshToken);
            if (user == null || user.RefreshTokenExpiry == null || user.RefreshTokenExpiry < DateTime.UtcNow)
                throw new UnauthorizedAccessException("Invalid or expired refresh token");

            var userRole = await _userRoleRepository.GetByIdAsync(user.UserRoleId)
                         ?? throw new InvalidOperationException("User role not found");

            var tokenExpiry = DateTime.UtcNow.AddHours(1);

            // Create a temporary response DTO (without token)
            var userResponse = new LoginUserResponseDto("", tokenExpiry, user.FullName, user.Email, userRole.RoleName);

            // Now generate the token using the response DTO
            var newToken = _jwtTokenService.GenerateToken(userResponse);
            var newRefreshToken = _jwtTokenService.GenerateRefreshToken();

            // Update user with new refresh token and expiry
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            // Return updated response DTO with new token
            return new LoginUserResponseDto(newToken, tokenExpiry, user.FullName, user.Email, userRole.RoleName);
        }


        public async Task LogoutUserAsync(LogoutUserRequestDto request)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(request.RefreshToken);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid refresh token");

            user.RefreshToken = null;
            user.RefreshTokenExpiry = null;
            await _userRepository.UpdateAsync(user);
        }

        public async Task ChangePasswordAsync(int userId, ChangePasswordRequestDto request)
        {
            var user = await _userRepository.GetByIdAsync(userId)
                       ?? throw new KeyNotFoundException("User not found");

            if (request.NewPassword != request.ConfirmNewPassword)
                throw new ArgumentException("New password and confirm password do not match");

            if (!_passwordHasher.VerifyPassword(request.OldPassword, user.PasswordHash))
                throw new UnauthorizedAccessException("Incorrect old password");

            user.PasswordHash = _passwordHasher.HashPassword(request.NewPassword);
            await _userRepository.UpdateAsync(user);
        }
    }
}
