using MediatR;


namespace Products_Management_API.Server.CQRS.Queries.Product
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Models.Product>> { }
}
