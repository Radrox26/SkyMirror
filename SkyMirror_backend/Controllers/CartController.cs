using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("AddCartProduct")]
        [ProducesResponseType(typeof(CartProduct), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProductToCart(AddCartProductRequestDto request)
        {
            if (request.ProductId<= 0 || request.ProductQuantity <= 0)
                return BadRequest("Invalid product ID or quantity.");

            var result = await _cartService.AddProductToCartAsync(request);
            return nameof(result) == "CartProduct"
                ? Ok(result)
                : BadRequest("Failed to add product to cart.");
        }
    }
}
