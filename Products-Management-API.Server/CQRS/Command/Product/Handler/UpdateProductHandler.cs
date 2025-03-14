using MediatR;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.CQRS.Command.Product.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct>
    {
        private readonly ProductRepository _productRepository;

        public UpdateProductHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task  Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetById(request.Id).Result;
            if (product == null) return Task.FromResult(false);

            product.Name = request.Name;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;

            _productRepository.Update(product);
            _productRepository.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
