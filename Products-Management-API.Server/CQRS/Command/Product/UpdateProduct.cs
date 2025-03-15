using MediatR;
using Products_Management_API.Server.Models;

namespace Products_Management_API.Server.CQRS.Command.Product
{
    public class UpdateProduct : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  Price Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
