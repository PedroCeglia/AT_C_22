using AT_C__2.Models;
using AT_C__2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly IClienteService _clienteService;

        public CreateModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync chamado");
            Console.WriteLine($"Dados recebidos: Nome={Cliente.Nome}, Email={Cliente.Email}");

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
                Console.WriteLine("Tentando adicionar cliente...");
                await _clienteService.AddClienteAsync(Cliente);
                Console.WriteLine("Cliente adicionado com sucesso");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar cliente: {ex}");
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
