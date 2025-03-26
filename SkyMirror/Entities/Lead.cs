using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class Lead
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int LeadId { get; private set; }

        [Required] // Ensures UserId is mandatory
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))] // Explicitly marks this as a Foreign Key
        public User Customer { get; set; } = null!;

        [Required] // Inquiry details must be provided
        [MaxLength(1000)] // Restricts length to avoid excessive data
        public string InquiryDetails { get; set; } = string.Empty;

        [Required] // Status must always have a value
        [MaxLength(50)] // Restricts length for optimization
        public string Status { get; set; } = "New";

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Set once at creation
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public ICollection<Quotation> Quotations { get; private set; } = new List<Quotation>();

    }
}
