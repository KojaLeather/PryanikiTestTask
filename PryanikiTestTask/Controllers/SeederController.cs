using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PryanikiTestTask.Data;
using PryanikiTestTask.Data.Models;

namespace PryanikiTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeederController : ControllerBase
    {
        private ApplicationDbContext _context;
        public SeederController (ApplicationDbContext context)
        {
            _context = context;
        }
        //Seeds the DB with products for testing
        [HttpPost("SeedDB")]
        public async Task<IActionResult> SeedDB()
        {
            if (_context.Products.Any())
            {
                return BadRequest("Products already existing, consider dropping the DB");
            }

            List<Product> products = new()
            {
                new Product {Name = "ProductForTest1", Category = "CategoryForTest1", Description = "DescriptonOfProduct1", Price=360.50, Quantity = 5},
                new Product {Name = "ProductForTest2", Category = "CategoryForTest1", Description = "DescriptonOfProduct2", Price=6331.50, Quantity = 5},
                new Product {Name = "ProductForTest3", Category = "CategoryForTest2", Description = "DescriptonOfProduct3", Price=641.50, Quantity = 5},
                new Product {Name = "ProductForTest4", Category = "CategoryForTest3", Description = "DescriptonOfProduct4", Price=532, Quantity = 5},
                new Product {Name = "ProductForTest5", Category = "CategoryForTest3", Description = "DescriptonOfProduct5", Price=130, Quantity = 5}
            };

            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();

            return Ok("Products has been seeded");
        }
    }
}
