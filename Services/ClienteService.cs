using AT_C__2.Models;
using AT_C__2.Repositories.Interfaces;
using AT_C__2.Services.Interfaces;
using AT_C__2.Validators;

namespace AT_C__2.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository packageRepository)
        {
            _clienteRepository = packageRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            ClienteValidator.ValidarCampos(cliente);
            await ClienteValidator.ValidarExclusividade(cliente, _clienteRepository);
            await _clienteRepository.AddAsync(cliente);
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            ClienteValidator.ValidarCampos(cliente);
            await ClienteValidator.ValidarExclusividade(cliente, _clienteRepository);
            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }
    }
}
