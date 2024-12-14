using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductShipmentAPI.Data;
using ProductShipmentAPI.Models;

namespace ProductShipmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            return await _context.Shipments.ToListAsync();
        }

        [HttpGet("bydate/{date}")]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipmentsByDate(DateTime date)
        {
            var shipments = await _context.Shipments
                .Where(s => s.ShipmentDate.Date == date.Date)
                .ToListAsync();

            if (shipments == null || shipments.Count == 0)
            {
                return NotFound();
            }

            return shipments;
        }

        
        [HttpGet("totalcost/{date}")]
        public async Task<ActionResult<decimal>> GetTotalCostByDate(DateTime date)
        {
            var totalCost = await _context.Shipments
                .Where(s => s.ShipmentDate.Date == date.Date)  
                .SumAsync(s => s.BatchCost); 

            if (totalCost == 0)
            {
                return NotFound(new { message = "No shipments found for this date." });
            }

            return Ok(new { totalCost });  
        }
        [HttpGet("shipmentreport/{productName}")]
        public async Task<ActionResult<IEnumerable<ShipmentReport>>> GetShipmentReport(string productName)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Name == productName);

            if (product == null)
            {
                return NotFound(new { message = $"Product with name {productName} not found." });
            }

            var shipments = await _context.Shipments
                .Where(s => s.ProductId == product.ProductId)
                .GroupBy(s => new { s.Store, s.ShipmentDate })
                .Select(g => new ShipmentReport
                {
                    Name = product.Name,
                    Store = g.Key.Store,
                    ShipmentDate = g.Key.ShipmentDate,
                    TotalBatchSize = g.Sum(s => s.BatchSize),
                    TotalBatchCost = g.Sum(s => s.BatchCost),
                    TotalWeight = g.Sum(s => s.BatchSize) 
                })
                .ToListAsync();

            if (shipments.Count == 0)
            {
                return NotFound(new { message = $"No shipments found for product {productName}." });
            }

            return Ok(shipments);
        }



    }
}
