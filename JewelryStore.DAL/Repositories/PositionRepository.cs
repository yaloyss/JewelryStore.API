using System;
using JewelryStore.DAL.Models;
using JewelryStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.DAL.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(DbContext context)
            : base(context) { }

        public async Task<Position> GetByNameAsync(string positionName)
        {
            return await dbSet.FirstOrDefaultAsync(p => p.PositionName == positionName);
        }
    }
}

