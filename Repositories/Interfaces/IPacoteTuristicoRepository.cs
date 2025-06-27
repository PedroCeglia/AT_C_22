using AT_C__2.Models;

namespace AT_C__2.Repositories.Interfaces
{
    public interface IPacoteTuristicoRepository
    {
        Task<IEnumerable<PacoteTuristico>> GetAllAsync();
        Task<PacoteTuristico?> GetByIdAsync(int id);
        Task AddAsync(PacoteTuristico pacoteTuristico);
        Task UpdateAsync(PacoteTuristico pacoteTuristico);
        Task DeleteAsync(int id);
    }
}
