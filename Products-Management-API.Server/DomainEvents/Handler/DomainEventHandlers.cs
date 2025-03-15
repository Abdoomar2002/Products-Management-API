using MediatR;
using Products_Management_API.Server.Models;
using Products_Management_API.Server.Repositories;

namespace Products_Management_API.Server.DomainEvents.Handler
{
    public class UpdateCategoryProductCountHandler :
         INotificationHandler<ProductCreatedEvent>,
         INotificationHandler<ProductDeletedEvent>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        public UpdateCategoryProductCountHandler(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        // 🔥 Handle Product Created Event
        public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(notification.CategoryId);
            if (category != null)
            {
                var productCount = _productRepository.GetAll().Result.Count(p => p.CategoryId == notification.CategoryId);
                category.Result.UpdateProductCount(productCount);
                _categoryRepository.SaveChanges();
            }
        }

        
        public async Task Handle(ProductDeletedEvent notification, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(notification.CategoryId);
            if (category != null)
            {
                var productCount = _productRepository.GetAll().Result.Count(p => p.CategoryId == notification.CategoryId);
                category.Result.UpdateProductCount(productCount);
                _categoryRepository.SaveChanges();
            }
        }
    }
}
