using MediatR;
using Products_Management_API.Server.Models;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.CQRS.Command.Category.Handler
{
        using Category = Server.Models.Category;
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateCategory request, CancellationToken cancellationToken)
        {
            var category = _repository.GetById(request.Id);
            if (category == null) throw new Exception("Category not found");
            category.Result.Name = request.Name;

            _repository.Update(category.Result);
            _repository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
