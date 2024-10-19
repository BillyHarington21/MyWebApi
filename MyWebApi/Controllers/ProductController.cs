using Domen.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;

namespace MyWebApi.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductDTO productDto)
        {
            try
            {
                var newProduct = await _productService.CreateProductAsync(productDto);
                return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDto)
        {
            var result = await _productService.UpdateProductAsync(id, productDto);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
