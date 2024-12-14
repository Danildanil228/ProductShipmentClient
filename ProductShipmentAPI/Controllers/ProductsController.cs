using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductShipmentAPI.Data; 
using ProductShipmentAPI.Models;
using System.Linq;

namespace ProductShipmentAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        
        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            
            var product = _context.Products.Find(id);

            
            if (product == null)
            {
                _logger.LogError($"Product with id {id} not found.");
                return NotFound(new { message = $"Product with ID {id} not found." });
            }

            
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();

            if (!products.Any())
            {
                _logger.LogWarning("No products found.");
                return NotFound(new { message = "No products found." });
            }

            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(new { message = "Product data is required." });
            }

            _context.Products.Add(product);
            _context.SaveChanges(); 

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]   
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null || product.ProductId != id)
            {
                return BadRequest(new { message = "Invalid product data." });
            }

            var existingProduct = _context.Products.Find(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            _context.SaveChanges();

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
        

    }
}
