using SkyMirror.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror_backend.Entities
{
    public class CartProduct
    {
        [ForeignKey(nameof(Cart))] // Foreign key to Cart
        public int CartId { get; set; }

        [ForeignKey(nameof(Product))] // Foreign key to Product
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int ProductQuantity { get; set; } 

        // Navigation Properties
        public Cart? Cart { get; set; }
        public Product? Product { get; set; } 

        // CartId + ProductId as composite primary key
    }
}
