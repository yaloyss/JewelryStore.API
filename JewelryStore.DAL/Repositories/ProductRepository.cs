using JewelryStore.DAL.Models;
using JewelryStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await dbSet
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByMetalAsync(string metal)
        {
            return await dbSet.Where(p => p.Metal == metal).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByStoneAsync(string stone)
        {
            return await dbSet.Where(p => p.Stone == stone).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByManufacturerAsync(string manufacturer)
        {
            return await dbSet.Where(p => p.Manufacturer == manufacturer).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            return await dbSet.Where(p => p.Name.Contains(name)).ToListAsync();
        }
    }
}

