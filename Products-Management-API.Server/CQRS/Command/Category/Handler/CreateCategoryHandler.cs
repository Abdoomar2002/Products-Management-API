using MediatR;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.Server.CQRS.Command.Category.Handler
{
    using Category = Models.Category;
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, Guid>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
            _repository.Add(category);
            _repository.SaveChanges();
            return Task.FromResult(category.Id);
        }
    }
}
