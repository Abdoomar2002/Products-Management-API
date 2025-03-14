using MediatR;
using Products_Management_API.Server.Models;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.CQRS.Queries.Product.Handler
{
    using Server.Models;
    public class GetProductByGuidHandler : IRequestHandler<GetProductByGuidQuery, Product>
    {
        private readonly IRepository<Product> _repository;

        public GetProductByGuidHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Task<Product> Handle(GetProductByGuidQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetById(request.Id)).Result;
        }
    }
}
