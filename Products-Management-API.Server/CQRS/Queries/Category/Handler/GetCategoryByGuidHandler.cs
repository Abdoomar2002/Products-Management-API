using MediatR;
using Products_Management_API.Server.Repositories;
using Products_Management_API.Server.CQRS.Queries.Category;

namespace Products_Management_API.CQRS.Queries.Category.Handler
{
    using Category = Server.Models.Category;
    public class GetCategoryByGuidHandler : IRequestHandler<GetCategoryByGuidQuery, Category>
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryByGuidHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> Handle(GetCategoryByGuidQuery request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(request.Id);
            return Task.FromResult(category).Result;
        }
    }
}
