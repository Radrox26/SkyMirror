using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class Quotation
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int QuotationId { get; private set; }

        [Required] // LeadId is mandatory
        public int LeadId { get; set; }

        [ForeignKey(nameof(LeadId))] // Explicitly marks this as a Foreign Key
        public Lead Lead { get; set; } = null!;

        [Required] // SalesManagerId is mandatory
        public int SalesManagerId { get; set; }

        [ForeignKey(nameof(SalesManagerId))] // Explicitly marks this as a Foreign Key
        public User SalesManager { get; set; } = null!;

        [Required] // Ensures TotalAmount is always set
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be non-negative.")]
        public decimal TotalAmount { get; set; }

        [Required] // Ensures Status is always set
        [MaxLength(50)] // Restricts length for optimization
        public string Status { get; set; } = "Pending";

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Set once at creation
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // Navigation Property (One-to-Many with QuotationItems)
        public ICollection<QuotationItem> QuotationItems { get; private set; } = new List<QuotationItem>();
    }
}
