using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class Product
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int ProductId { get; private set; }

        [Required] // Name is mandatory
        [MaxLength(200)] // Limits name length
        public string PanelName { get; set; } = string.Empty;

        [Required] // Category is mandatory
        [MaxLength(100)] // Limits category length
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ProductCategory Category { get; set; } = null!;

        [MaxLength(500)] // Limits description length (optional)
        public string Description { get; set; } = string.Empty;

        [Required] // Price is mandatory
        [Range(0, double.MaxValue)] // Ensures price is non-negative
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100)]
        public int PowerInWatts { get; set; }


        [Required] // Stock quantity is mandatory
        [Range(0, int.MaxValue)] // Ensures stock is non-negative
        public int StockQuantity { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-set on creation
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

        // Navigation Property (One-to-Many with QuotationItems)
        public ICollection<QuotationItem> QuotationItems { get; private set; } = new List<QuotationItem>();

        // Navigation Property (One-to-Many with QuotationItems)
        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
    }
}
