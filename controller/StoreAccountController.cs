using Microsoft.AspNetCore.Mvc;
using EazyTrade.Dto;
using EazyTrade.Interface.Service;
using Microsoft.AspNetCore.Authorization;

namespace EazyTrade.Controller
{
    [Route("[controller]")]
    public class StoreAccountController : ControllerBase
    {
        private readonly IStoreAccountService _service;

        public StoreAccountController(IStoreAccountService service)
        {
            _service = service;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllStoreAccount()
        {
            var queries = await _service.GetStoreAccountsAsync();
            if (queries == null || queries.Count == 0)
            {
                return NotFound();
            }

            return Ok(queries);
        }

        [Authorize(Roles = "admin, vendor")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStoreAccountById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = await _service.GetStoreAccountByIdAsync(id);

            if (query == null)
            {
                return NotFound($"The id {id} is not found");
            }

            return Ok(query);
        }

        [Authorize(Roles = "admin, vendor")]
        [HttpPost()]
        public async Task<IActionResult> CreateStoreAccount([FromBody] StoreAccountForManipulationDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateStoreAccountAsync(payload);
            return Ok(result);
        }

        [Authorize(Roles = "admin, vendor")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStoreAccount([FromRoute] int id, [FromBody] StoreAccountForManipulationDto payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateStoreAccountAsync(id, payload);
            if (result == null)
            {
                return NotFound($"The id {id} is not found");
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin, vendor")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStoreAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deleted = await _service.DeleteStoreAccountAsync(id);
            if (!deleted)
            {
                return NotFound($"The id {id} is not found");
            }

            return NoContent();
        }
    }
}