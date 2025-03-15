using MediatR;
using Products_Management_API.Server.CQRS.Queries.Category;
using Products_Management_API.Server.Models;
using Products_Management_API.Server.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Products_Management_API.CQRS.Queries.Category.Handler
{
    using Category = Server.Models.Category;
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery,IEnumerable<Category>>
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetAllCategoriesHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepository.GetAll();
            return Task.FromResult(categories).Result;
        }
    }
}
