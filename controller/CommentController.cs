using EazyTrade.Data;
using EazyTrade.Interface;
using EazyTrade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EazyTrade.Controller
{
    [Route("[Controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICommentRepository _repository;

        public CommentController(ApplicationDBContext context, ICommentRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var queries = await _repository.GetAllAsync();
            if (queries == null || queries.Count == 0)
            {
                return NotFound();
            }

            return Ok(queries);
        }

        // Note: removed duplicate HttpGet action that returned raw list
        // to avoid Swagger/OpenAPI conflicting method/path definitions.
    }
}