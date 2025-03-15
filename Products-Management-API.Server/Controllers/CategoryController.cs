using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products_Management_API.CQRS.Command.Category;
using Products_Management_API.CQRS.Queries.Category;
using Products_Management_API.Server.CQRS.Queries.Category;
using Products_Management_API.Server.Models;

namespace Products_Management_API.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategory command)
        {
            var categoryId = await _mediator.Send(command);
            return Ok(categoryId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategory command)
        {
            if (id != command.Id)
            {
                return BadRequest("Category ID mismatch");
            }

            var result =  _mediator.Send(command);
            return result.IsCompletedSuccessfully ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var command = new DeleteCategory { Id = id };
            var result =  _mediator.Send(command);
            return result.IsCompletedSuccessfully ? NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var query = new GetCategoryByGuidQuery { Id = id };
            var category = await _mediator.Send(query);
            return category != null ? Ok(category) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await _mediator.Send(query);
            return categories.Count()>0? Ok(categories):NoContent();
        }
    }
}
