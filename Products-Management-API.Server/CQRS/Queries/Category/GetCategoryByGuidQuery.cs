using MediatR;

namespace Products_Management_API.Server.CQRS.Queries.Category
{
    public class GetCategoryByGuidQuery : IRequest<Models.Category>
    {
        public Guid Id { get; set; }
    }
}
