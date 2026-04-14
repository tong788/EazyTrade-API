using EazyTrade.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EazyTrade.Mapper;
using EazyTrade.Dtos;
using EazyTrade.Interfaces;
using EazyTrade.Repository;
namespace EazyTrade.Controller
{
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICommodityRepository _repository;
        public CommodityController(ApplicationDBContext context, ICommodityRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommodity()
        {
            var queries = await _repository.GetAllAsync();
            if (queries == null || queries.Count == 0)
            {
                return NotFound();
            }
            return Ok(queries);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommodityById([FromRoute] int id)
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

        [HttpPost()]
        public async Task<IActionResult> CreateCommodity([FromBody] CommodityForManipulationDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commodityModel = payload.ToCommodityFromManipulation();
            await _context.AddAsync(commodityModel);
            await _context.SaveChangesAsync();
            return Ok(commodityModel);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCommodity([FromRoute] int id, [FromBody] CommodityForManipulationDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commodityModel = await _context.Commodities.FirstOrDefaultAsync(c => c.Id == id);

            if (commodityModel == null)
            {
                return NotFound();
            }

            commodityModel.Name = payload.Name;
            commodityModel.Price = payload.Price;
            commodityModel.PublishDate = payload.PublishDate;
            commodityModel.CancelDate = payload.CancelDate;

            await _context.SaveChangesAsync();

            return Ok(commodityModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCommodity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commodityModel = await _context.Commodities.FirstOrDefaultAsync(c => c.Id == id);

            if (commodityModel == null)
            {
                return NotFound();
            }

            _context.Remove(commodityModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}