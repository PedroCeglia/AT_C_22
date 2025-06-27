using AT_C__2.Models;
using AT_C__2.Repositories.Interfaces;
using AT_C__2.Services.Interfaces;
using AT_C__2.Utils;
using AT_C__2.Validators;

namespace AT_C__2.Services
{
    public class PacoteTuristicoService : IPacoteTuristicoService
    {
        private readonly IPacoteTuristicoRepository _pacoteTuristicoRepository;

        public PacoteTuristicoService(IPacoteTuristicoRepository pacoteTuristicoRepository)
        {
            _pacoteTuristicoRepository = pacoteTuristicoRepository;
        }

        public async Task<IEnumerable<PacoteTuristico>> GetAllPacoteTuristicoAsync()
        {
            return await _pacoteTuristicoRepository.GetAllAsync();
        }

        public async Task<decimal> GetPrecoComDescontoAsync(int pacoteId)
        {
            var pacote = await _pacoteTuristicoRepository.GetByIdAsync(pacoteId);

            if (pacote == null)
                throw new KeyNotFoundException("Nao Encontrou");

            CalculoDescontoDelegate calcular = CalculateDelegate.AplicarDescontoAmericaSul;

            return calcular(pacote);
        }

        public async Task<PacoteTuristico?> GetPacoteTuristicoByIdAsync(int id)
        {
            return await _pacoteTuristicoRepository.GetByIdAsync(id);
        }

        public async Task AddPacoteTuristicoAsync(PacoteTuristico pacoteTuristico)
        {
            PacoteTuristicoValidator.ValidarCampos(pacoteTuristico);
            await _pacoteTuristicoRepository.AddAsync(pacoteTuristico);
        }

        public async Task UpdatePacoteTuristicoAsync(PacoteTuristico pacoteTuristico)
        {
            PacoteTuristicoValidator.ValidarCampos(pacoteTuristico);
            await _pacoteTuristicoRepository.UpdateAsync(pacoteTuristico);
        }

        public async Task DeletePacoteTuristicoAsync(int id)
        {
            await _pacoteTuristicoRepository.DeleteAsync(id);
        }
    }
}
