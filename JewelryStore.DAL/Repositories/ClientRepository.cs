using JewelryStore.DAL.Models;
using JewelryStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.DAL.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContext context)
            : base(context) { }

        public async Task<Client> GetByFullNameAsync(string firstName, string lastName)
        {
            return await dbSet.FirstOrDefaultAsync(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public async Task<IEnumerable<Client>> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await dbSet.Where(c => c.PhoneNumber == phoneNumber).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetByBirthDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await dbSet
                .Where(c => c.BirthDate.HasValue &&
                           c.BirthDate.Value >= startDate &&
                           c.BirthDate.Value <= endDate)
                .ToListAsync();
        }
    }
}

