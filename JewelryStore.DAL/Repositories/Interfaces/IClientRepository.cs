using JewelryStore.DAL.Models;

namespace JewelryStore.DAL.Repositories.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Client> GetByFullNameAsync(string firstName, string lastName);
        Task<IEnumerable<Client>> GetByPhoneNumberAsync(string phoneNumber);
        Task<IEnumerable<Client>> GetByBirthDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}

