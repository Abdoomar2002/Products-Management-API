using MediatR;

namespace Products_Management_API.CQRS.Queries.Product
{
    public class GetProductByGuidQuery : IRequest<Server.Models.Product>
    {
        public Guid Id { get; set; }
    }
}
