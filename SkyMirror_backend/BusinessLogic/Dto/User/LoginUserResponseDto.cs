namespace SkyMirror.BusinessLogic.Dto.User
{
    public class LoginUserResponseDto
    {
        public string AccessToken { get; }
        public DateTime AccessTokenExpiresAt { get; }
        public string FullName { get; }
        public string Email { get; }
        public string RoleName { get; }

        public string? RefreshToken { get; set; } // for cookie
        public DateTime? RefreshTokenExpiry { get; set; }

        public LoginUserResponseDto(string token, DateTime expiresAt, string fullName, string email, string roleName)
        {
            AccessToken = token;
            AccessTokenExpiresAt = expiresAt;
            FullName = fullName;
            Email = email;
            RoleName = roleName;
        }
    }
}
