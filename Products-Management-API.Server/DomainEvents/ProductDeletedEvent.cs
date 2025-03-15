using MediatR;

namespace Products_Management_API.Server.DomainEvents
{
    public class ProductDeletedEvent : INotification
    {
        public Guid CategoryId { get; }

        public ProductDeletedEvent(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
