using AT_C__2.Models;

namespace AT_C__2.Services.Interfaces
{
    public interface IDestinoService
    {
        Task<IEnumerable<Destino>> GetAllDestinosAsync();
        Task<Destino?> GetDestinoByIdAsync(int id);
        Task AddDestinoAsync(Destino destino);
        Task UpdateDestinoAsync(Destino destino);
        Task DeleteDestinoAsync(int id);
    }
}
