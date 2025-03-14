using MediatR;

namespace Products_Management_API.CQRS.Command.Category
{
    public class CreateCategory : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
