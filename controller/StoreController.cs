using Microsoft.AspNetCore.Mvc;
using EazyTrade.Dto;
using EazyTrade.Interface.Service;

namespace EazyTrade.Controller
{
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _service;

        public StoreController(IStoreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStore()
        {
            var queries = await _service.GetStoresAsync();
            if (queries == null || queries.Count == 0)
            {
                return NotFound();
            }

            return Ok(queries);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStoreById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = await _service.GetStoreByIdAsync(id);

            if (query == null)
            {
                return NotFound($"The id {id} is not found");
            }

            return Ok(query);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateStore([FromBody] StoreForManipulationDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateStoreAsync(payload);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStore([FromRoute] int id, [FromBody] StoreForManipulationDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateStoreAsync(id, payload);
            if (result == null)
            {
                return NotFound($"The id {id} is not found");
            }

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStore([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deleted = await _service.DeleteStoreAsync(id);
            if (!deleted)
            {
                return NotFound($"The id {id} is not found");
            }

            return NoContent();
        }
    }
}