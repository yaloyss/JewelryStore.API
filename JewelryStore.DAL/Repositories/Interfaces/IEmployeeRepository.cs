using JewelryStore.DAL.Models;

namespace JewelryStore.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetByPositionIdAsync(int positionId);
        Task<IEnumerable<Employee>> GetByNameAsync(string firstName, string lastName);
        Task<Employee> GetWithPositionAsync(int employeeId);
        Task<IEnumerable<Employee>> GetAllWithPositionsAsync();
    }
}

