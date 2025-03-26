using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class Order
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int OrderId { get; private set; }

        [Required] // UserId is mandatory
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))] // Explicitly marks as a Foreign Key
        public User Customer { get; set; } = null!;

        [Required] // Ensures TotalAmount is always set
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than zero.")]
        public decimal TotalAmount { get; set; }

        [Required] // Ensures Status is always set
        [StringLength(20)] // Restricts Status length
        public string Status { get; set; } = "Pending"; // Status can be updated

        [Required] // Ensures OrderDate is always set
        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;

        // Navigation Property (One-to-Many with QuotationItems)
        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

        // Navigation Property (One-to-One with Payment)
        public Payment Payment { get; private set; } = new Payment();
    }
}
