using EazyTrade.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EazyTrade.Mapper;
namespace EazyTrade.Controller
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
            var queries = await _context.Commodities.Select(c => c.ToCommodityDto()).ToListAsync();
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

            var query = await _context.Commodities.FindAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }
    }
}