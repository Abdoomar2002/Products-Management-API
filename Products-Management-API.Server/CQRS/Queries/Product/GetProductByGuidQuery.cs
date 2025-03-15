using MediatR;

namespace Products_Management_API.Server.CQRS.Queries.Product
{
    public class GetProductByGuidQuery : IRequest<Models.Product>
    {
        public Guid Id { get; set; }
    }
}
