using System.ComponentModel.DataAnnotations;

namespace SkyMirror.BusinessLogic.Dto.User
{
    public class UpdateUserRequestDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

    }
}
