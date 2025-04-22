namespace SkyMirror.BusinessLogic.Dto.UserRole
{
    public class UserRoleResponseDto
    {
        public string RoleName { get; }

        public UserRoleResponseDto(string roleName)
        {
            RoleName = roleName;
        }
    }
}
