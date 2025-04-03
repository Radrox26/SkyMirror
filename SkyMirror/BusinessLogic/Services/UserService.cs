using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkyMirror.BusinessLogic.Dto.User;
using SkyMirror.BusinessLogic.Dto.UserRole;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Entities;

namespace SkyMirror.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var usersResponse = new List<UserResponseDto>();

            foreach (var user in users)
            {
                var userRole = await _userRoleRepository.GetByIdAsync(user.UserRoleId);
                var userRoleResponse = userRole != null
                    ? new UserRoleResponseDto(userRole.RoleName)
                    : new UserRoleResponseDto("Unknown");

                usersResponse.Add(new UserResponseDto(user.UserId, user.FullName, user.Email, userRoleResponse, user.CreateDate));
            }

            return usersResponse;
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId)
                       ?? throw new KeyNotFoundException("User not found");

            var userRole = await _userRoleRepository.GetByIdAsync(user.UserRoleId);
            var userRoleResponse = userRole != null
                ? new UserRoleResponseDto(userRole.RoleName)
                : new UserRoleResponseDto("Unknown");

            return new UserResponseDto(user.UserId, user.FullName, user.Email, userRoleResponse, user.CreateDate);
        }

        public async Task RegisterUserAsync(CreateUserRequestDto request)
        {
            if (await _userRepository.GetByEmailAsync(request.Email) != null)
                throw new InvalidOperationException("Email already in use");

            var userRole = await _userRoleRepository.GetByNameAsync(request.RoleName)
                           ?? throw new InvalidOperationException("Invalid role specified");

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = "", // Password will be handled in AuthService
                UserRoleId = userRole.UserRoleId
            };

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(int userId, UpdateUserRequestDto request)
        {
            var user = await _userRepository.GetByIdAsync(userId)
                       ?? throw new KeyNotFoundException("User not found");

            if (user.Email != request.Email && await _userRepository.GetByEmailAsync(request.Email) != null)
                throw new InvalidOperationException("Email already in use");

            user.FullName = request.FullName;
            user.Email = request.Email;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId)
                       ?? throw new KeyNotFoundException("User not found");

            await _userRepository.DeleteAsync(user.UserId);
        }
    }
}
