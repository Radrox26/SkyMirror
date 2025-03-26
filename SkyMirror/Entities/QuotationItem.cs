using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class QuotationItem
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int QuotationItemId { get; private set; }

        [Required] // QuotationId is mandatory
        public int QuotationId { get; set; }

        [ForeignKey(nameof(QuotationId))] // Explicitly marks as a Foreign Key
        public Quotation Quotation { get; set; } = null!;

        [Required] // ProductId is mandatory
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))] // Explicitly marks as a Foreign Key
        public Product Product { get; set; } = null!;

        [Required] // Ensures Quantity is always set
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required] // Ensures Price is always set
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }
}
