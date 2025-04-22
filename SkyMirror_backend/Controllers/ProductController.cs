using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.Product;
using SkyMirror.BusinessLogic.Interfaces;

namespace SkyMirror.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            if (products == null || !products.Any())
                return NoContent();

            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _productService.CreateProductAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateProductRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _productService.GetProductByIdAsync(id);
            if (existing == null)
                return NotFound($"Product with ID {id} not found.");

            await _productService.UpdateProductAsync(id, request);
            return NoContent();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _productService.GetProductByIdAsync(id);
            if (existing == null)
                return NotFound($"Product with ID {id} not found.");

            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
