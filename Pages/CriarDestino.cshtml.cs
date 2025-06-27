using AT_C__2.Models;
using AT_C__2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages
{
    public class CriarDestinoModel : PageModel
    {
        private readonly IDestinoService _destinoService;

        public CriarDestinoModel(IDestinoService destinoService)
        {
            _destinoService = destinoService;
        }

        [BindProperty]
        public Destino Destino { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState inválido");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Erro: {error.ErrorMessage}");
                }
                return Page();
            }

            try
            {
                await _destinoService.AddDestinoAsync(Destino);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erro ao criar destino.");
                return Page();
            }
        }
    }
}
