using Microsoft.AspNetCore.Mvc;
using SkyMirror_backend.BusinessLogic.Dto.Cart;
using SkyMirror_backend.BusinessLogic.Dto.CartProduct;
using SkyMirror_backend.BusinessLogic.Interfaces;
using SkyMirror_backend.Entities;

namespace SkyMirror.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // POST: api/Cart/AddCartProduct
        [HttpPost]
        [Route("AddCartProduct")]
        [ProducesResponseType(typeof(CartProduct), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProductToCart(AddCartProductRequestDto request)
        {
            if (request.ProductId<= 0 || request.ProductQuantity <= 0)
                return BadRequest("Invalid product ID or quantity.");

            var result = await _cartService.AddProductToCartAsync(request);

            return Ok(result);
        }

        // GET: api/Cart/GetCartProducts/{cartId}
        [HttpGet("GetCartProducts/{cartId}")]
        [ProducesResponseType(typeof(IEnumerable<GetProductInCartResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetCartProducts(int cartId)
        {
            var cartProducts = await _cartService.GetCartProductsAsync(cartId);
            if (cartProducts == null || !cartProducts.Any())
                return NoContent();

            return Ok(cartProducts);
        }
    }
}
