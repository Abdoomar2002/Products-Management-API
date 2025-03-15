using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products_Management_API.Server.CQRS.Command.Category;
using Products_Management_API.Server.CQRS.Queries.Category;
using Products_Management_API.Server.Exceptions;
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
            if (string.IsNullOrWhiteSpace(command.Name))
                throw new ApiException("Category name is required", 400);

            var categoryId = await _mediator.Send(command);

            if (categoryId == Guid.Empty)
                throw new ApiException("Failed to create category", 500);

            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryId }, categoryId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategory command)
        {
            if (id != command.Id)
                throw new ApiException("Category ID mismatch", 400);

            var result =  _mediator.Send(command);

            if (!result.IsCompletedSuccessfully)
                throw new ApiException("Category not found", 404);

            return NoContent(); // 204 for successful update with no content
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var command = new DeleteCategory { Id = id };
            var result =  _mediator.Send(command);

            if (!result.IsCompletedSuccessfully)
                throw new ApiException("Category not found", 404);

            return NoContent(); // 204 for successful deletion with no content
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var query = new GetCategoryByGuidQuery { Id = id };
            var category = await _mediator.Send(query);

            if (category == null)
                throw new ApiException("Category not found", 404);

            return Ok(category); // 200 for successful retrieval
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await _mediator.Send(query);

            if (categories == null || !categories.Any())
                return NoContent(); // 204 if no categories found

            return Ok(categories); // 200 if categories exist
        }
    }
}
