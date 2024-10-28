using BuilderPatternAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BuilderPatternAPI.Services
{
    public class ProductService
    {
        private readonly ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync(); 
        }

        public async Task<List<Product>> SearchProductsAsync(ProductSearchRequest request)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query.Where(p => p.Category == request.Category);
            }

            if (request.MinPrice > 0)
            {
                query = query.Where(p => p.Price >= request.MinPrice);
            }

            if (request.MaxPrice > 0)
            {
                query = query.Where(p => p.Price <= request.MaxPrice);
            }

            return await query.ToListAsync(); 
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id); 
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product); 
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id); 
            if (product != null)
            {
                _context.Products.Remove(product); 
                await _context.SaveChangesAsync(); 
            }
        }
    }

}
