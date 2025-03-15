using MediatR;

namespace Products_Management_API.Server.DomainEvents
{
    public class ProductCreatedEvent : INotification
    {
        public Guid CategoryId { get; }

        public ProductCreatedEvent(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
