using System;
using System.Threading.Tasks;
using Evt.Test.Data;
using Evt.Test.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Evt.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {      
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Customers /GET");

            using var db = new EvtContext();
            var customers = await db.Set<Customer>().ToArrayAsync();
            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult> Get(int customerId)
        {
            _logger.LogInformation($"Customers/{customerId} /GET");

            using var db = new EvtContext();
            var customer = await db.Set<Customer>().FindAsync(customerId);
            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Customer customer)
        {
            _logger.LogInformation($"Customers /POST");

            customer.CreatedAt = DateTimeOffset.UtcNow;

            using var db = new EvtContext();
            db.Add(customer);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), customer.CustomerId);
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> Put(int customerId, Customer customer)
        {
            _logger.LogInformation($"Customers/{customerId} /PUT");

            customer.UpdatedAt = DateTimeOffset.UtcNow;

            using var db = new EvtContext();
            var exists = await db.Set<Customer>().AnyAsync(c => c.CustomerId == customerId);
            if(!exists)
            {
                return NotFound();
            }

            customer.CustomerId = customerId;
            db.Update(customer);
            await db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> Delete(int customerId)
        {
            _logger.LogInformation($"Customers/{customerId} /DELETE");

            using var db = new EvtContext();
            var customer = await db.Set<Customer>().FindAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            db.Remove(customer);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
