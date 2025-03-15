using MediatR;

namespace Products_Management_API.Server.CQRS.Command.Category
{
    public class CreateCategory : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
