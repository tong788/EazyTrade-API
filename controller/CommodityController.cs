using EazyTrade.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace controller
{
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CommodityController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCommodity()
        {
            var queries = await _context.Commodity.ToListAsync();
            if (queries == null || queries.Count == 0)
            {
                return NotFound();
            }
            return Ok(queries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCommodityById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = await _context.Commodity.FindAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }
    }
}