using MediatR;

namespace Products_Management_API.CQRS.Command.Product
{
    public class DeleteProduct : IRequest
    {
        public Guid Id { get; set; }
    }
}
