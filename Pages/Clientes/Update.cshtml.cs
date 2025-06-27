using AT_C__2.Models;
using AT_C__2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages.Clientes
{
    public class UpdateModel : PageModel
    {
        private readonly IClienteService _clienteService;

        public UpdateModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Console.WriteLine($"OnGetAsync chamado com id={id}");
            try
            {
                Cliente = await _clienteService.GetClienteByIdAsync(id);
                if (Cliente == null)
                {
                    Console.WriteLine($"Cliente com id={id} não encontrado");
                    return NotFound();
                }
                Console.WriteLine($"Cliente encontrado: Id={Cliente.Id}, Nome={Cliente.Nome}, Email={Cliente.Email}");
                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar cliente com id={id}: {ex.Message}");
                return StatusCode(500, "Erro interno ao carregar cliente");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine($"OnPostAsync chamado: Id={Cliente.Id}, Nome={Cliente.Nome}, Email={Cliente.Email}");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState inválido. Erros:");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Erro: {error.ErrorMessage}");
                }
                return Page();
            }

            try
            {
                Console.WriteLine("Tentando atualizar cliente...");
                await _clienteService.UpdateClienteAsync(Cliente);
                Console.WriteLine("Cliente atualizado com sucesso");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
