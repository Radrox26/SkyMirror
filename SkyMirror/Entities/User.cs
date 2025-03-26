using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class User
    {
        [Key] // Marks this as the Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures Auto-Increment
        public int UserId { get; private set; }

        [Required] // FullName cannot be null
        [MaxLength(100)] // Limits name to 100 characters
        public string FullName { get; set; } = string.Empty;

        [Required] // Email is mandatory
        [EmailAddress] // Ensures proper email format
        [MaxLength(150)] // Limits email length to 150 characters
        public string Email { get; set; } = string.Empty;

        [Required] // Phone number is required
        [Phone] // Ensures phone number format
        [MaxLength(15)] // Limits phone number length
        public string PhoneNumber { get; set; } = string.Empty;

        [Required] // PasswordHash is required
        public string PasswordHash { get; set; } = string.Empty;

        // Foreign Key for UserRole
        [ForeignKey(nameof(UserRole))]
        public int UserRoleId { get; set; }

        // Navigation Property
        public UserRole? UserRole { get; set; }

        // Timestamp
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-set on creation
        public DateTime CreateDate { get; private set; } = DateTime.UtcNow;
    }
}
