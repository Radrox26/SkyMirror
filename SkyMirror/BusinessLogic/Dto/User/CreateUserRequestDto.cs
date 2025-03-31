using System.ComponentModel.DataAnnotations;

namespace SkyMirror.BusinessLogic.Dto.User
{
    public class CreateUserRequestDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string RoleName { get; private set; } = "Customer"; // Default role
    }
}
