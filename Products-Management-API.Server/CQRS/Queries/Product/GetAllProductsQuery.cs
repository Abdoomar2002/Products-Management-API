using MediatR;


namespace Products_Management_API.CQRS.Queries.Product
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Server.Models.Product>> { }
}
