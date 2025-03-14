using MediatR;
using Products_Management_API.Server.Models;
using System.Collections.Generic;

namespace Products_Management_API.CQRS.Queries.Product
{
    public class GetProductsByCategoryQuery : IRequest<IEnumerable<Server.Models.Product>>
    {
        public Guid CategoryId { get; set; }
    }
}
