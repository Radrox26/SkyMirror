using Microsoft.EntityFrameworkCore;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;
using SkyMirror_backend.DataAccess.Interfaces;
using SkyMirror_backend.Entities;

namespace SkyMirror_backend.DataAccess.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly SkyMirrorDbContext _context;

        public CartRepository(SkyMirrorDbContext context)
        {
            _context = context;
        }

        public Task<Cart?> GetCartByIdAsync(int cartId)
        {
            return _context.Carts
                    .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                    .FirstOrDefaultAsync(c => c.CartId == cartId);
        }

        public Task<CartProduct?> GetProductInCartByIdAsync(int cartId, int productId)
        {
            return _context.CartProducts
                .Include(cp => cp.Product)
                .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);
        }

        public async Task<Cart> AddCartAsync(int userId)
        {
            var cart = new Cart { UserId = userId };
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart; // Return the auto-generated ID
        }

        public async Task<CartProduct> AddProductToCartAsync(CartProduct cartProduct)
        {
            await _context.CartProducts.AddAsync(cartProduct);
            await _context.SaveChangesAsync();
            return cartProduct; // Return the auto-generated ID
        }

        public async Task UpdateProductInCartAsync(CartProduct updatedProduct)
        {
            var existingProduct = await _context.CartProducts.FindAsync(updatedProduct.CartId, updatedProduct.ProductId);
            if (existingProduct == null) return;

            existingProduct.ProductQuantity = updatedProduct.ProductQuantity;
            // Update other properties as needed

            await _context.SaveChangesAsync();
        }

        public Task ClearCartAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCartAsync(int cartId)
        {
            throw new NotImplementedException();
        }
        public Task<Cart?> GetCartByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromCartAsync(int cartId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
