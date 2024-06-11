using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PryanikiTestTask.Data;
using PryanikiTestTask.Data.Models.DTO.OrderDTOs;
using PryanikiTestTask.Data.Models;
using PryanikiTestTask.Data.Models.DTO.ProductDTOs;

namespace PryanikiTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ApplicationDbContext _context;
        public OrderController (ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetOrders")]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            var orders = await _context.Orders.OrderBy(e => e.OrderId).ToListAsync();

            if (orders.Count == 0) return NotFound();

            var ordersDto = orders.Select(e => new OrderDto
            {
                OrderId = e.OrderId,
                OrderDate = e.OrderDate,
                Status = e.Status,
                SumPrice = e.SumPrice
            }).ToList();
            return ordersDto;
        }

        //Quite massive action, maybe will implement some helpers or triggers to make it smaller
        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder(CreateOrderDto orderDto)
        {
            var transactions = await _context.Database.BeginTransactionAsync();
            try
            {
                double sumPrice = 0;
                foreach (var product in orderDto.Products)
                {
                    //Get price from DB
                    var productPrice = await _context.Products.Where(e => e.ProductId == product.ProductId).Select(e => e.Price).FirstOrDefaultAsync();

                    if (productPrice == 0) return NotFound();

                    sumPrice += productPrice * product.Count;

                    //Subtracts the current quantity based on count of products of the same type in order
                    var productToUpdateQuantity = await _context.Products.FindAsync(product.ProductId);
                    productToUpdateQuantity.Quantity -= product.Count;

                    if (productToUpdateQuantity.Quantity < 0) return BadRequest("Quantity cannot be less than 0");
                }
                var order = new Order
                {
                    OrderDate = orderDto.OrderDate,
                    Status = orderDto.Status,
                    SumPrice = sumPrice
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                //Bad implementation but cannot think of anything else because I need orderId to fill many-to-many table
                foreach (var product in orderDto.Products)
                {
                    var productOrder = new ProductOrder
                    {
                        OrderId = order.OrderId,
                        ProductId = product.ProductId,
                        Quantity = product.Count
                    };

                    _context.ProductOrder.Add(productOrder);
                }

                await _context.SaveChangesAsync();

                await transactions.CommitAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                await transactions.RollbackAsync();
                return BadRequest(ex);
            }
        }
    }
}
