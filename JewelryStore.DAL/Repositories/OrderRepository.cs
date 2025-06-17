using System;
using JewelryStore.DAL.Models;
using JewelryStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context)
            : base(context) { }

        public async Task<IEnumerable<Order>> GetByClientIdAsync(int clientId)
        {
            return await dbSet.Where(o => o.ClientId == clientId).Include(o => o.Product).ToListAsync();
        }

        //public async Task<IEnumerable<Order>> GetByEmployeeIdAsync(int employeeId)
        //{
        //    return await dbSet.Where(o => o.EmployeeId == employeeId).ToListAsync();
        //}

        public async Task<IEnumerable<Order>> GetByProductIdAsync(int productId)
        {
            return await dbSet.Where(o => o.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await dbSet
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetWithDetailsAsync()
        {
            return await dbSet
                    .Include(o => o.Client)    
                    //.Include(o => o.Employee)              
                        //.ThenInclude(e => e.Position)    
                    .Include(o => o.Product)                  
                    .ToListAsync();

        }

        public async Task<object> GetAllWithDetailsAsync(int orderId)
        {
            return await dbSet
                    .Where(o => o.OrderId == orderId)
                    .Select(o => new
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate,

                        ClientFirstName = o.Client.FirstName,
                        ClientLastName = o.Client.LastName,
                        ClientPhone = o.Client.PhoneNumber,

                        //EmployeeFirstName = o.Employee.FirstName,
                        //EmployeeLastName = o.Employee.LastName,
                        //EmployeePosition = o.Employee.Position.PositionName,

                        ProductName = o.Product.Name,
                        ProductPrice = o.Product.Price
                    })
                .FirstOrDefaultAsync();
        }
    }
}

