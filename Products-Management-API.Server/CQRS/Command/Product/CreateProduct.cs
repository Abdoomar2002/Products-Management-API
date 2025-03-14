namespace Products_Management_API.Server.CQRS.Command.Product
{
    using global::Products_Management_API.Server.Models;
    using MediatR;

    namespace Products_Management_API.CQRS.Command.Product
    {
        public class CreateProduct : IRequest<Guid>
        {
            public string Name { get; set; }
            public Guid CategoryId { get; set; }
            public Price Price { get; set; }
        }
    }

}
