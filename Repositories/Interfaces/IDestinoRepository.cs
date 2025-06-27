using AT_C__2.Models;

namespace AT_C__2.Repositories.Interfaces
{
    public interface IDestinoRepository
    {
        Task<IEnumerable<Destino>> GetAllAsync();
        Task<Destino?> GetByIdAsync(int id);
        Task AddAsync(Destino destino);
        Task UpdateAsync(Destino destino);
        Task DeleteAsync(int id);
    }
}
