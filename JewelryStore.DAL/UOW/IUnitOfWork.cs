using JewelryStore.DAL.Repositories.Interfaces;

namespace JewelryStore.DAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IPositionRepository Positions { get; }
        IEmployeeRepository Employees { get; }
        IClientRepository Clients { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }

        Task<int> SaveChangesAsync();
    }
}

