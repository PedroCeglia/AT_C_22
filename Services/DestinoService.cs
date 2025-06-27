using AT_C__2.Models;
using AT_C__2.Repositories.Interfaces;
using AT_C__2.Services.Interfaces;
using AT_C__2.Validators;

namespace AT_C__2.Services
{
    public class DestinoService : IDestinoService
    {
        private readonly IDestinoRepository _destinoRepository;

        public DestinoService(IDestinoRepository destinoRepository)
        {
            _destinoRepository = destinoRepository;
        }

        public async Task<IEnumerable<Destino>> GetAllDestinosAsync()
        {
            return await _destinoRepository.GetAllAsync();
        }

        public async Task<Destino?> GetDestinoByIdAsync(int id)
        {
            return await _destinoRepository.GetByIdAsync(id);
        }

        public async Task AddDestinoAsync(Destino destino)
        {
            DestinoValidator.ValidarCampos(destino);
            await _destinoRepository.AddAsync(destino);
        }

        public async Task UpdateDestinoAsync(Destino destino)
        {
            DestinoValidator.ValidarCampos(destino);
            await _destinoRepository.UpdateAsync(destino);
        }

        public async Task DeleteDestinoAsync(int id)
        {
            await _destinoRepository.DeleteAsync(id);
        }
    }
}
