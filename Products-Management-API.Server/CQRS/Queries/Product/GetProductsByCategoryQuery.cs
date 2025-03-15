using MediatR;
namespace Products_Management_API.Server.CQRS.Queries.Product
{
    public class GetProductsByCategoryQuery : IRequest<IEnumerable<Models.Product>>
    {
        public Guid CategoryId { get; set; }
    }
}
