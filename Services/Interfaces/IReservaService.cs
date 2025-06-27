using AT_C__2.Models;

namespace AT_C__2.Services.Interfaces
{
    public interface IReservaService
    {
        Task<IEnumerable<Reserva>> GetAllReservaAsync();
        Task<Reserva?> GetReservaByIdAsync(int id);
        Task AddReservaAsync(Reserva reserva);
        Task UpdateReservaAsync(Reserva reserva);
        Task DeleteReservaAsync(int id);
    }
}
