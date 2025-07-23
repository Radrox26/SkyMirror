using SkyMirror.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMirror_backend.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures Auto-Increment
        public int CartId {  get; private set; }

        [ForeignKey(nameof(User))] // Foreign key to User
        public int UserId { get; set; }

        // Navigation Properties
        public User? User { get; set; } 
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    }
}
