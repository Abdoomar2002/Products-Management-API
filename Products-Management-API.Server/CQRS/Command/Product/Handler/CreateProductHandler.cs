using MediatR;
using Products_Management_API.Server.DomainEvents;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.Server.CQRS.Command.Product.Handler
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, Guid>
    {
        private readonly ProductRepository _repository;
        private readonly IMediator _mediator;

        public CreateProductHandler(ProductRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var product = new Server.Models.Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CategoryId = request.CategoryId,
                Price = request.Price
            };

            await _repository.Add(product);
            await _repository.SaveChanges();
            await _mediator.Publish(new ProductCreatedEvent(product.CategoryId));
            return product.Id;
        }
    }
}
