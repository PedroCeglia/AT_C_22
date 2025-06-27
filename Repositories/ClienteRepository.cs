using AT_C__2.Data;
using AT_C__2.Models;
using AT_C__2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AT_C__2.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AgenciaViagensDB _context;
        private readonly DbSet<Cliente> _dbSet;
        public ClienteRepository(AgenciaViagensDB context)
        {
            _context = context;
            _dbSet = _context.Set<Cliente>();
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _dbSet.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Cliente? cliente = await _dbSet.FindAsync(id);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente {id} not found.");
            cliente.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _dbSet.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            await _dbSet
                .Where(c => c.Id == cliente.Id)
                .ExecuteUpdateAsync(c => c
                    .SetProperty(c => c.Nome, cliente.Nome)
                    .SetProperty(c => c.Email, cliente.Email));

            await _context.SaveChangesAsync();
        }
    }
}
