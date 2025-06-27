using AT_C__2.Models;
using AT_C__2.Repositories;
using AT_C__2.Repositories.Interfaces;
using AT_C__2.Services.Interfaces;
using AT_C__2.Utils;
using AT_C__2.Validators;
using Microsoft.Extensions.Logging;

namespace AT_C__2.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IPacoteTuristicoRepository _pacoteTuristicoRepository;

        public ReservaService(IReservaRepository reservaRepository, IPacoteTuristicoRepository pacoteTuristicoRepository)
        {
            _reservaRepository = reservaRepository;
            _pacoteTuristicoRepository = pacoteTuristicoRepository;
        }

        public async Task<IEnumerable<Reserva>> GetAllReservaAsync()
        {
            return await _reservaRepository.GetAllAsync();
        }

        public async Task<Reserva?> GetReservaByIdAsync(int id)
        {
            return await _reservaRepository.GetByIdAsync(id);
        }

        public async Task AddReservaAsync(Reserva reserva)
        {
            ReservaValidator.ValidarCampos(reserva);

            Action<string> log = Log.LogToConsole;
            log += Log.LogToFile;
            log += Log.LogToMemory;

            await _reservaRepository.AddAsync(reserva);
            log("Reserva adicionada com sucesso!");

            PacoteTuristico? pacoteTuristico = await _pacoteTuristicoRepository.GetByIdAsync(reserva.PacoteTuristicoId);

            if (pacoteTuristico == null)
                throw new Exception("Pacote turístico não encontrado.");

            pacoteTuristico.CapacityReached += (sender, args) =>
            {
                Console.WriteLine("Numero maximo de Reservas.");
            };

            pacoteTuristico.AdicionarReserva(reserva);

            await _pacoteTuristicoRepository.UpdateAsync(pacoteTuristico);

        }

        public async Task UpdateReservaAsync(Reserva reserva)
        {
            ReservaValidator.ValidarCampos(reserva);
            await _reservaRepository.UpdateAsync(reserva);
        }

        public async Task DeleteReservaAsync(int id)
        {
            await _reservaRepository.DeleteAsync(id);
        }
    }
}
