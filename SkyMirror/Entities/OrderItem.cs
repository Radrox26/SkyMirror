using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror.Entities
{
    public class OrderItem
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int OrderItemId { get; private set; }

        [Required] // OrderId is mandatory
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))] // Explicit Foreign Key declaration
        public Order Order { get; set; } = null!;

        [Required] // ProductId is mandatory
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))] // Explicit Foreign Key declaration
        public Product Product { get; set; } = null!;

        [Required] // Quantity cannot be null
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required] // Price cannot be null
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }
}
