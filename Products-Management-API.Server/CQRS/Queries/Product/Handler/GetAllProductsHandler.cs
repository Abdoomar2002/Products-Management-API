using MediatR;
using Products_Management_API.Server.Models;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.CQRS.Queries.Product.Handler
{
    using Products_Management_API.Server.Models;
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IRepository<Product> _repository;

        public GetAllProductsHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.GetAll()).Result;
        }
    }
}
