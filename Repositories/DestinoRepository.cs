using AT_C__2.Data;
using AT_C__2.Models;
using AT_C__2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AT_C__2.Repositories
{
    public class DestinoRepository : IDestinoRepository
    {
        private readonly AgenciaViagensDB _context;
        private readonly DbSet<Destino> _dbSet;
        public DestinoRepository(AgenciaViagensDB context)
        {
            _context = context;
            _dbSet = _context.Set<Destino>();
        }

        public async Task AddAsync(Destino destino)
        {
            await _dbSet.AddAsync(destino);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Destino destino = await GetByIdAsync(id);
            if (destino != null)
            {
                _dbSet.Remove(destino);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Cliente {id} not found.");
            }
        }

        public async Task<IEnumerable<Destino>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Destino?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(Destino destino)
        {
            await _dbSet
                .Where(d => d.Id == destino.Id)
                .ExecuteUpdateAsync(d => d
                    .SetProperty(d => d.Nome, destino.Nome)
                    .SetProperty(d => d.Pais, destino.Pais));

            await _context.SaveChangesAsync();
        }
    }
}
