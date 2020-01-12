using Evt.Test.Data;
using Evt.Test.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Evt.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Orders /GET");

            using (var db = new EvtContext())
            {
                var order = from o in db.Orders
                            join p in db.Products on o.ProductId equals p.ProductId
                            join c in db.Customers on o.CustomerId equals c.CustomerId
                            select new
                            {
                                o.OrderId,
                                c.FirstName,
                                c.LastName,
                                Product = p.Name,
                                p.Description,
                                p.Price,
                            };

                return Ok(await order.ToListAsync());
            }

        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult> Get(int orderId)
        {
            _logger.LogInformation($"Orders/{orderId} /GET");

            using var db = new EvtContext();
            var customer = await db.Set<Order>().FindAsync(orderId);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Order order)
        {
            _logger.LogInformation($"Orders /POST");

            order.CreatedAt = DateTimeOffset.UtcNow;

            using var db = new EvtContext();
            db.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), order.OrderId);
        }


        [HttpPut("{orderId}")]
        public async Task<ActionResult> Put(int orderId, Order order)
        {
            _logger.LogInformation($"Orders/{orderId} /PUT");

            order.UpdatedAt = DateTimeOffset.UtcNow;

            using var db = new EvtContext();
            var exists = await db.Set<Order>().AnyAsync(c => c.OrderId == orderId);
            if (!exists)
            {
                return NotFound();
            }

            order.OrderId = orderId;
            db.Update(order);
            await db.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{orderId}")]
        public async Task<ActionResult> Delete(int orderId)
        {
            _logger.LogInformation($"Orders/{orderId} /DELETE");

            using var db = new EvtContext();
            var orders = await db.Set<Order>().FindAsync(orderId);
            if (orders == null)
            {
                return NotFound();
            }

            db.Remove(orders);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
