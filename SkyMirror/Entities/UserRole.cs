using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class UserRole
    {
        [Key] // Marks this as the Primary Key (not necessary but explicit)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment (Identity)
        public int UserRoleId { get; private set; }

        [Required] // Ensures RoleName is not null
        [MaxLength(50)] // Limits RoleName to 50 characters
        public string RoleName { get; private set; } = string.Empty;

        // Navigation Property (One-to-Many with Users)
        public ICollection<User> Users { get; private set; } = new List<User>();
    }
}
