using SkyMirror.BusinessLogic.Dto.UserRole;

namespace SkyMirror.BusinessLogic.Dto.User
{
    public class UserResponseDto
    {
        public int Id { get; }
        public string FullName { get; }
        public string Email { get; }
        public UserRoleResponseDto Role { get; }
        public DateTime CreatedDate { get; }

        public UserResponseDto(int id, string fullName, string email, UserRoleResponseDto role, DateTime createdDate)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Role = role;
            CreatedDate = createdDate;
        }
    }
}
