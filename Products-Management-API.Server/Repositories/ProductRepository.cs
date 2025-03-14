using Microsoft.EntityFrameworkCore;
using Products_Management_API.Server.Data;
using Products_Management_API.Server.Models;

namespace Products_Management_API.Server.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}


