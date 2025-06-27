using AT_C__2.Models;
using AT_C__2.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages.Clientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IClienteService _clienteService;

        public IndexModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> Clientes { get; set; }

        public async Task OnGetAsync()
        {
            Clientes = await _clienteService.GetAllClientesAsync();
        }
    }
}
