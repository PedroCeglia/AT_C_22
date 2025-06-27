using AT_C__2.Models;

namespace AT_C__2.Services.Interfaces
{
    public interface IPacoteTuristicoService
    {
        Task<IEnumerable<PacoteTuristico>> GetAllPacoteTuristicoAsync();
        Task<PacoteTuristico?> GetPacoteTuristicoByIdAsync(int id);
        Task AddPacoteTuristicoAsync(PacoteTuristico pacoteTuristico);
        Task UpdatePacoteTuristicoAsync(PacoteTuristico pacoteTuristico);
        Task DeletePacoteTuristicoAsync(int id);
        Task<decimal> GetPrecoComDescontoAsync(int pacoteId);
    }
}
