using MediatR;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.CQRS.Queries.Product.Handler
{
    using Products_Management_API.Server.Models;
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<Product>>
    {
        private readonly ProductRepository _repository;

        public GetProductsByCategoryHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Product>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetProductsByCategory(request.CategoryId)).Result;
        }
    }
}
