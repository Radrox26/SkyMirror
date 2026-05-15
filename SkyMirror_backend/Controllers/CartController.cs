using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Interfaces;
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
        private readonly IUserService _userService;

        public CartController(ICartService cartService, IUserService userService)
        {
            _cartService = cartService;
            _userService = userService;
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
        [Authorize(Roles = "Customer")]
        [HttpGet("GetCartProducts")]
        [ProducesResponseType(typeof(IEnumerable<GetProductInCartResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetCartProducts()
        {
            var claims = User.Claims.ToList();
            var email = User.FindFirst("Email")?.Value;

            if(email == null)
                return Unauthorized("Unauthorized Access");

            var userId = await _userService.GetUserIdByEmailAsync(email);

            //We always have userId same as cartId.
            var cartProducts = await _cartService.GetCartProductsAsync(userId);
            if (cartProducts == null || !cartProducts.Any())
                return NoContent();

            return Ok(cartProducts);
        }
    }
}
