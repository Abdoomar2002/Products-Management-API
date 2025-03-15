using MediatR;
using Products_Management_API.Server.DomainEvents;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.Server.CQRS.Command.Product.Handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct>
    {
        private readonly ProductRepository _productRepository;
        private readonly IMediator _mediator;

        public DeleteProductHandler(ProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public Task Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetById(request.Id);
            if (product == null) return Task.FromResult(false);

            _productRepository.Delete(product.Result);
            _productRepository.SaveChanges();
             _mediator.Publish(new ProductDeletedEvent(product.Result.CategoryId));

            return Task.CompletedTask;
        }
    }
}
