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
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        //
        public ProductsController(ILogger<ProductsController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            this._logger.LogInformation("Products /GET");

            using var db = new EvtContext();
            var products = await db.Set<Product>().ToListAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult> Get(int productId)
        {
            this._logger.LogInformation($"Products/{productId} /GET");

            using var db = new EvtContext();
            var product = await db.Set<Product>().FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            this._logger.LogInformation($"Products /POST");

            product.CreatedAt = DateTimeOffset.UtcNow;

            using var db = new EvtContext();
            db.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), product.ProductId);
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> Put(int productId, Product product)
        {
            this._logger.LogInformation($"Products/{productId} /PUT");

            product.UpdatedAt = DateTimeOffset.UtcNow;

            using var db = new EvtContext();
            var exists = await db.Set<Product>().AnyAsync(p => p.ProductId == productId);
            if (!exists)
            {
                return NotFound();
            }

            product.ProductId = productId;
            db.Update(product);
            await db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(int productId)
        {
            _logger.LogInformation($"Products/{productId} /DELETE");

            using var db = new EvtContext();
            var product = await db.Set<Product>().FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            db.Remove(product);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
