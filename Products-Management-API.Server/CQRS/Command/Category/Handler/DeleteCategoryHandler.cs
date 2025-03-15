using MediatR;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.Server.CQRS.Command.Category.Handler
{
    using Category = Server.Models.Category;
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory>
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            var category = _repository.GetById(request.Id);
            if (category == null) throw new Exception("Category not found");

            _repository.Delete(category.Result);
            _repository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
