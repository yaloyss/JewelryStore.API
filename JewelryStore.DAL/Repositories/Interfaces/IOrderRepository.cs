using JewelryStore.DAL.Models;

namespace JewelryStore.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<Order>> GetByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<Order>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Order>> GetWithDetailsAsync();
        Task<object> GetAllWithDetailsAsync(int orderId);
    }
}

