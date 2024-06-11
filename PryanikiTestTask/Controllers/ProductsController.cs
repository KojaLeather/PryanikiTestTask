using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PryanikiTestTask.Data;
using PryanikiTestTask.Data.Models.DTO;
using PryanikiTestTask.Data.Models;
using PryanikiTestTask.Data.Models.DTO.ProductDTOs;

namespace PryanikiTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var products = await _context.Products.OrderBy(e => e.ProductId).ToListAsync();

            if (products.Count == 0) return NotFound();

            var productsDto = products.Select(e => new ProductDto
            {
                ProductId = e.ProductId,
                Name = e.Name,
                Category = e.Category,
                Description = e.Description,
                Price = e.Price,
                Quanity = e.Quantity
            }).ToList();
            return productsDto;
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductsById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == id);

            if (product == null) return NotFound();

            var productsDto = new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price,
                Quanity = product.Quantity
            };
            return productsDto;
        }
        [HttpGet("GetProductsByCategory")]
        public async Task<ActionResult<List<ProductDto>>> GetProducts(string category)
        {
            var products = await _context.Products.Where(e => e.Category == category).OrderBy(e => e.ProductId).ToListAsync();

            if (products.Count == 0) return NotFound();

            var productsDto = products.Select(e => new ProductDto
            {
                ProductId = e.ProductId,
                Name = e.Name,
                Category = e.Category,
                Description = e.Description,
                Price = e.Price,
                Quanity = e.Quantity
            }).ToList();

            return productsDto;
        }

        [HttpPut("ChangeProduct")]
        public async Task<ActionResult> ChangeProduct(Product product)
        {
            try
            {
                var isExists = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == product.ProductId);

                if (isExists == null) return NotFound();

                _context.Attach(product);
                _context.Entry(product).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(ProductToAddDto product)
        {
            Product productToAdd = new()
            {
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            };
            try
            {
                await _context.Products.AddAsync(productToAdd);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }
        [HttpDelete("DeleteProductById")]
        public async Task<ActionResult> DeleteProductById(int id)
        {
            var productToDelete = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == id);

            if (productToDelete == null) return NotFound();

            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
