using Microsoft.EntityFrameworkCore;
using SkyMirror.Entities;
using SkyMirror_backend.Entities;

namespace SkyMirror.DatabaseContext
{
    public class SkyMirrorDbContext : DbContext
    {
        public SkyMirrorDbContext(DbContextOptions<SkyMirrorDbContext> options) : base(options) { }
        // 📌 DbSet for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Configure Relationships & Constraints

            // UserRole - User (One-to-Many)
            modelBuilder.Entity<UserRole>()
                .HasMany(ur => ur.Users)
                .WithOne(u => u.UserRole)
                .HasForeignKey(u => u.UserRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - Lead (One-to-Many) - Prevent accidental lead deletion
            modelBuilder.Entity<User>()
                .HasMany(u => u.Leads)
                .WithOne(l => l.Customer)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lead - Quotation (One-to-Many) - Preserve quotations if lead is deleted
            modelBuilder.Entity<Lead>()
                .HasMany(l => l.Quotations)
                .WithOne(q => q.Lead)
                .HasForeignKey(q => q.LeadId)
                .OnDelete(DeleteBehavior.Restrict);

            // Quotation - QuotationItem (One-to-Many) - Delete items if quotation is deleted
            modelBuilder.Entity<Quotation>()
                .HasMany(q => q.QuotationItems)
                .WithOne(qi => qi.Quotation)
                .HasForeignKey(qi => qi.QuotationId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProductCategory - Product (One-to-Many) - Prevents product category deletion if referenced
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product - QuotationItem (One-to-Many) - Prevent product deletion if referenced
            modelBuilder.Entity<Product>()
                .HasMany(p => p.QuotationItems)
                .WithOne(qi => qi.Product)
                .HasForeignKey(qi => qi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order - OrderItem (One-to-Many) - Delete order items if order is deleted
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product - OrderItem (One-to-Many) - Prevent product deletion if referenced in an order
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order - Payment (One-to-One) - Keep payments even if order is deleted
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - Cart (One-to-One) - Delete cart if user is deleted
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartProduct>()
                .HasKey(cp => new { cp.CartId, cp.ProductId }); // Composite Key for CartProduct

            // CartProduct - Cart (Many-to-One) - Delete cart products if cart is deleted
            modelBuilder.Entity<CartProduct>()
                .HasOne(cp => cp.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(cp => cp.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            // CartProduct - Product (Many-to-One) - Delete cart products if product is deleted
            modelBuilder.Entity<CartProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Convert Column Names to camelCase
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(Char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1));
                }
            }
        }
    }
}
