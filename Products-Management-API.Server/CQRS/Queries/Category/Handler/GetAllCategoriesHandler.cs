using MediatR;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.Server.CQRS.Queries.Category.Handler
{
    using Category = Models.Category;
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
