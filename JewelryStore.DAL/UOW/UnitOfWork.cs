using System;
using JewelryStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public IClientRepository Clients { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }
        public IEmployeeRepository Employees { get; }
        public IPositionRepository Positions { get; }

        public UnitOfWork(DbContext context,
                          IClientRepository clients,
                          IOrderRepository orders,
                          IProductRepository products,
                          IEmployeeRepository employees,
                          IPositionRepository positions)
        {
            this.context = context;
            Clients = clients;
            Orders = orders;
            Products = products;
            Employees = employees;
            Positions = positions;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

