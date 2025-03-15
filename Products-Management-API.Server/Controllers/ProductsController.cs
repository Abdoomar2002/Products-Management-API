using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products_Management_API.CQRS.Command.Product;
using Products_Management_API.CQRS.Queries.Product;
using Products_Management_API.Server.CQRS.Command.Product.Products_Management_API.CQRS.Command.Product;
using Products_Management_API.Server.Models;

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
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = new GetProductByGuidQuery { Id = id };
            var product = await _mediator.Send(query);
            return product != null ? Ok(product) : NotFound();
        }
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);
            return products?.Count() > 0 ? Ok(products) : NoContent();
        }
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProduct command)
        {
            command.Id = id;
           var result= _mediator.Send(command);
            if(result.IsCompleted)
            if (result.IsCompletedSuccessfully) return Ok(id);
            else if (result?.Exception != null) return NotFound(result.Exception);
            else return BadRequest();
            else return NotFound();
        }
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProduct { Id = id };
            var result =  _mediator.Send(command);
            if (result.IsCompleted) 
             if (result.IsCompletedSuccessfully) return Ok();
             else if (result?.Exception != null) return BadRequest(result.Exception);
             else return BadRequest();
            else return NotFound();
        }
        public async Task<IActionResult> GetProductsByCategory(Guid categoryId)
        {
            var query = new GetProductsByCategoryQuery { CategoryId = categoryId };
            var products = await _mediator.Send(query);
            return products?.Count() > 0 ? Ok(products) : NoContent() ;
        }
    }
}
