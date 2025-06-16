using JewelryStore.DAL.Models;

namespace JewelryStore.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<Product>> GetByMetalAsync(string metal);
        Task<IEnumerable<Product>> GetByStoneAsync(string stone);
        Task<IEnumerable<Product>> GetByManufacturerAsync(string manufacturer);
        Task<IEnumerable<Product>> GetByNameAsync(string name);
    }
}

