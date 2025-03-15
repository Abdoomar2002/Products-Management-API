using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products_Management_API.Server.CQRS.Command.Product;
using Products_Management_API.Server.CQRS.Queries.Product;
using Products_Management_API.Server.Exceptions;

namespace Products_Management_API.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct command)
        {
            if (string.IsNullOrWhiteSpace(command.Name) || command.Price.Value <= 0)
                throw new ApiException("Product name and valid price are required", 400);
            if (command.CategoryId == Guid.Empty)
                throw new ApiException("Category ID is required", 400);
            var productId = await _mediator.Send(command);

            if (productId == Guid.Empty)
                throw new ApiException("Failed to create product", 500);

            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProduct command)
        {
            if (id != command.Id)
                throw new ApiException("Product ID mismatch", 400);

            var result =  _mediator.Send(command);

            if (!result.IsCompletedSuccessfully)
                throw new ApiException("Product not found", 404);

            return NoContent(); // 204 for successful update
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProduct { Id = id };
            var result =  _mediator.Send(command);

            if (!result.IsCompletedSuccessfully)
                throw new ApiException("Product not found", 404);

            return NoContent(); // 204 for successful deletion
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = new GetProductByGuidQuery { Id = id };
            var product = await _mediator.Send(query);

            if (product == null)
                throw new ApiException("Product not found", 404);

            return Ok(product); // 200 for successful retrieval
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);

            if (products == null || !products.Any())
                return NoContent(); // 204 if no products found

            return Ok(products); // 200 if products exist
        }

        [HttpGet("GetProductsByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(Guid categoryId)
        {
            var query = new GetProductsByCategoryQuery { CategoryId = categoryId };
            var products = await _mediator.Send(query);

            if (products == null || !products.Any())
                return NoContent(); // 204 if no products found for category

            return Ok(products);
        }
    }
}
