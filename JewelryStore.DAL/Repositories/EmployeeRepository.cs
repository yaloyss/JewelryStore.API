using System;
using JewelryStore.DAL.Models;
using JewelryStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context)
            : base(context) { }

        public async Task<IEnumerable<Employee>> GetByPositionIdAsync(int positionId)
        {
            return await dbSet.Where(e => e.PositionId == positionId).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetByNameAsync(string firstName, string lastName)
        {
            return await dbSet
                .Where(e => e.FirstName == firstName && e.LastName == lastName)
                .ToListAsync();
        }

        public async Task<Employee> GetWithPositionAsync(int employeeId)
        {
            return await dbSet
                .Include(e => e.Position)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllWithPositionsAsync()
        {
            return await dbSet
                .Include(e => e.Position)
                .ToListAsync();
        }
    }
}

