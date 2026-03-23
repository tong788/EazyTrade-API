using EazyTrade.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult getAllCommodity()
        {
            var commodities = _context.Commodity.ToList();
            return Ok(commodities);
        }

        [HttpGet("{id}")]
        public IActionResult getCommodityById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var query = _context.Commodity.Find(id);

            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }
    }
}