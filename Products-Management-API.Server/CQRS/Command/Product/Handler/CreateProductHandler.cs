using MediatR;
using Products_Management_API.Server.CQRS.Command.Product.Products_Management_API.CQRS.Command.Product;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.CQRS.Command.Product.Handler
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, Guid>
    {
        private readonly ProductRepository _repository;

        public CreateProductHandler(ProductRepository repository)
        {
            _repository = repository;
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

            return product.Id;
        }
    }
}
