using SkyMirror.Entities;
using SkyMirror_backend.Entities;

namespace SkyMirror_backend.DataAccess.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByIdAsync(int cartId);

        Task<Cart?> GetCartByUserIdAsync(int userId);

        Task<CartProduct?> GetProductInCartByIdAsync(int cartId, int productId);

        Task<Cart> AddCartAsync(int userId);

        Task<CartProduct> AddProductToCartAsync(CartProduct cartProduct);

        Task UpdateProductInCartAsync(CartProduct cartProduct);

        Task DeleteCartAsync(int cartId);

        Task RemoveProductFromCartAsync(int cartId, int productId);

        Task ClearCartAsync(int cartId);


        Task SaveChangesAsync();
    }
}
