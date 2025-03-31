namespace SkyMirror.BusinessLogic.Dto.User
{
    public class LoginUserResponseDto
    {
        public string Token { get; }
        public DateTime ExpiresAt { get; }
        public string FullName { get; }
        public string Email { get; }
        public string RoleName { get; }

        public LoginUserResponseDto(string token, DateTime expiresAt, string fullName, string email, string roleName)
        {
            Token = token;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Email = email;
            RoleName = roleName;
        }
    }
}
