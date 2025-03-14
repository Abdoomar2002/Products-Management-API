using MediatR;

namespace Products_Management_API.Server.CQRS.Queries.Category
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Models.Category>> 
    {
    }
}
