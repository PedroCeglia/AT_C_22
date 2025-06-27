using AT_C__2.Data;
using AT_C__2.Models;
using AT_C__2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AT_C__2.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AgenciaViagensDB _context;
        private readonly DbSet<Reserva> _dbSet;
        public ReservaRepository(AgenciaViagensDB context)
        {
            _context = context;
            _dbSet = _context.Set<Reserva>();
        }

        public async Task AddAsync(Reserva reserva)
        {
            await _dbSet.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Reserva reserva = await GetByIdAsync(id);
            if (reserva != null)
            {
                _dbSet.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"PacoteTuristico não encontrado.");
            }
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(Reserva reserva)
        {
            await _dbSet
                .Where(r => r.Id == reserva.Id)
                .ExecuteUpdateAsync(r => r
                    .SetProperty(r => r.DataReserva, reserva.DataReserva)
                );

            await _context.SaveChangesAsync();
        }
    }
}
