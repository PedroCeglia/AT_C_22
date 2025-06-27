using AT_C__2.Models;
using AT_C__2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly IClienteService _clienteService;

        public DeleteModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cliente = await _clienteService.GetClienteByIdAsync(id);

            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
