using EeFee.Data;
using EeFee.Models;
using EeFee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EeFee.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly EeFeeContext _context;

        public PositionRepository(EeFeeContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Position position)
        {
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
        }

        public void Delete(Position position)
        {
            _context.Positions.Remove(position);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Position>> FindAllAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> FindByIdAsync(int id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task UpdateAsync(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
