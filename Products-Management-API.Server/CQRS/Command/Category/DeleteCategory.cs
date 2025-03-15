using MediatR;

namespace Products_Management_API.Server.CQRS.Command.Category
{
    public class DeleteCategory : IRequest
    {
        public Guid Id { get; set; }
    }
}
