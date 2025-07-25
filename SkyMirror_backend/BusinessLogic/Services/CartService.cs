using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Entities;
using SkyMirror_backend.BusinessLogic.Dto.Cart;
using SkyMirror_backend.BusinessLogic.Dto.CartProduct;
using SkyMirror_backend.BusinessLogic.Interfaces;
using SkyMirror_backend.DataAccess.Interfaces;
using SkyMirror_backend.Entities;

namespace SkyMirror_backend.BusinessLogic.Services
{
    public class CartService : 
        ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public CartService(ICartRepository cartProductRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _cartRepository = cartProductRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<Cart> AddCartAsync(int userId)
        {
            if(userId <= 0)
            {
                throw new ArgumentException("User ID must be greater than zero.", nameof(userId));
            }

            var existingUser = await _userRepository.GetByIdAsync(userId);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} does not exist.");
            }

            var cart = await _cartRepository.AddCartAsync(userId);

            return cart;
        }

        public async Task<CartProduct> AddProductToCartAsync(AddCartProductRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            if (request.ProductQuantity <= 0 )
            {
                throw new ArgumentException("Product quantity must be greater than zero.", nameof(request.ProductQuantity));
            }

            if(request.CartId <= 0)
            {
                throw new ArgumentException("Cart ID must be greater than zero.", nameof(request.CartId));
            }

            var cart = await _cartRepository.GetCartByIdAsync(request.CartId);
            if (cart == null)
            {
                throw new InvalidOperationException($"Cart with ID {request.CartId} does not exist.");
            }

            if (request.ProductId <= 0)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(request.ProductId));
            }

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.ProductId} does not exist.");
            }

            var singleCartProduct = await _cartRepository.GetProductInCartByIdAsync(request.CartId, request.ProductId);
            if (singleCartProduct != null)
            {
                var cartProduct = new CartProduct
                {
                    CartId = request.CartId,
                    ProductId = request.ProductId,
                    ProductQuantity = singleCartProduct.ProductQuantity + request.ProductQuantity
                };

                await _cartRepository.UpdateProductInCartAsync(cartProduct);
                return cartProduct;
            }

            var cartProductToAdd = new CartProduct
            {
                CartId = request.CartId,
                ProductId = request.ProductId,
                ProductQuantity = request.ProductQuantity
            };
            await _cartRepository.AddProductToCartAsync(cartProductToAdd);
            return cartProductToAdd;
        }

        public async Task<IEnumerable<GetProductInCartResponseDto>> GetCartProductsAsync(int cartId)
        {
            if (cartId <= 0)
            {
                throw new ArgumentException("Cart ID must be greater than zero.", nameof(cartId));
            }

            var cart = await _cartRepository.GetCartByIdAsync(cartId);

            if (cart == null)
            {
                throw new InvalidOperationException($"Cart with ID {cartId} does not exist.");
            }

            List<GetProductInCartResponseDto> responseCartProducts = new List<GetProductInCartResponseDto>();

            foreach(var cartProduct in cart.CartProducts)
            {
                if (cartProduct.Product == null)
                    return responseCartProducts;

                responseCartProducts.Add( new GetProductInCartResponseDto(
                        cartProduct.Product.PanelName,
                        cartProduct.ProductQuantity,
                        cartProduct.Product.Price)
                    );
            }

            return responseCartProducts;

        }
    }
}
