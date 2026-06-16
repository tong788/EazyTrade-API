using Microsoft.AspNetCore.Mvc;
using EazyTrade.Dto;
using EazyTrade.Interface.Service;
using Microsoft.AspNetCore.Authorization;

namespace EazyTrade.Controller
{
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ICommodityService _service;
        public CommodityController(ICommodityService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCommodity()
        {
            var queries = await _service.GetCommodities(trackChanges: false);
            if (queries == null || queries.Count == 0)
            {
                return NotFound();
            }
            return Ok(queries);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommodityById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = await _service.GetCommodityById(id, trackChanges: false);

            if (query == null)
            {
                return NotFound($"The id {id} is not found");
            }

            return Ok(query);
        }

        [Authorize(Roles = "admin,vendor")]
        [HttpPost()]
        public async Task<IActionResult> CreateCommodity([FromBody] CommodityForManipulationDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateCommodity(payload);
            return Ok(result);
        }

        [Authorize(Roles = "admin,vendor")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCommodity([FromRoute] int id, [FromBody] CommodityForManipulationDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateCommodity(id, payload);
            if (result == null)
            {
                return NotFound($"The id {id} is not found");
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin,vendor")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCommodity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deleted = await _service.DeleteCommodity(id);
            if (!deleted)
            {
                return NotFound($"The id {id} is not found");
            }

            return NoContent();
        }
    }
}