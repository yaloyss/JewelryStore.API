using JewelryStore.DAL.Models;
namespace JewelryStore.DAL.Repositories.Interfaces
{
    public interface IPositionRepository : IGenericRepository<Position>
    {
        Task<Position> GetByNameAsync(string positionName);
    }
}

