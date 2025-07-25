using SkyMirror.Entities;
using SkyMirror_backend.BusinessLogic.Dto.Cart;
using SkyMirror_backend.BusinessLogic.Dto.CartProduct;
using SkyMirror_backend.Entities;

namespace SkyMirror_backend.BusinessLogic.Interfaces
{
    public interface ICartService
    {
        Task<Cart> AddCartAsync(int userId);
        Task<CartProduct> AddProductToCartAsync(AddCartProductRequestDto request);
        Task<IEnumerable<GetProductInCartResponseDto>> GetCartProductsAsync(int cartId);
    }
}
