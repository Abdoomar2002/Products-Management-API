using MediatR;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.CQRS.Command.Product.Handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct>
    {
        private readonly ProductRepository _productRepository;

        public DeleteProductHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetById(request.Id);
            if (product == null) return Task.FromResult(false);

            _productRepository.Delete(product.Result);
            _productRepository.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
