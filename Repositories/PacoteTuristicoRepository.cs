using AT_C__2.Data;
using AT_C__2.Models;
using AT_C__2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AT_C__2.Repositories
{
    public class PacoteTuristicoRepository : IPacoteTuristicoRepository
    {
        private readonly AgenciaViagensDB _context;
        private readonly DbSet<PacoteTuristico> _dbSet;
        public PacoteTuristicoRepository(AgenciaViagensDB context)
        {
            _context = context;
            _dbSet = _context.Set<PacoteTuristico>();
        }

        public async Task AddAsync(PacoteTuristico pacoteTuristico)
        {
            await _dbSet.AddAsync(pacoteTuristico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            PacoteTuristico pacoteTuristico = await GetByIdAsync(id);
            if (pacoteTuristico != null)
            {
                _dbSet.Remove(pacoteTuristico);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"PacoteTuristico não encontrado.");
            }
        }

        public async Task<IEnumerable<PacoteTuristico>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<PacoteTuristico?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(PacoteTuristico pacoteTuristico)
        {
            await _dbSet
                .Where(p => p.Id == pacoteTuristico.Id)
                .ExecuteUpdateAsync(d => d
                    .SetProperty(p => p.Titulo, pacoteTuristico.Titulo)
                    .SetProperty(p => p.DataInicio, pacoteTuristico.DataInicio)
                    .SetProperty(p => p.CapacidadeMaxima, pacoteTuristico.CapacidadeMaxima)
                    .SetProperty(p => p.Preco, pacoteTuristico.Preco)
                    .SetProperty(p => p.Destinos, pacoteTuristico.Destinos)
                    );

            await _context.SaveChangesAsync();
        }
    }
}
