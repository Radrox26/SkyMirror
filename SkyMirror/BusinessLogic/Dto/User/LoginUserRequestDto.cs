using System.ComponentModel.DataAnnotations;

namespace SkyMirror.BusinessLogic.Dto.User
{
    public class LoginUserRequestDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
