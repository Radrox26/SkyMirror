using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class Payment
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int PaymentId { get; private set; }

        [Required] // OrderId is mandatory
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))] // Explicit Foreign Key declaration
        public Order Order { get; set; } = null!;

        [Required] // AmountPaid cannot be null
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal AmountPaid { get; set; }

        [Required] // PaymentStatus is mandatory
        [MaxLength(20)] // Limits the status string length
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Completed, Failed

        [Required] // PaymentDate cannot be null
        public DateTime PaymentDate { get; private set; } = DateTime.UtcNow;
    }
}
