using AT_C__2.Models;
using AT_C__2.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages
{
    public class TesteModel : PageModel
    {
        public PacoteTuristico Pacote { get; set; }
        public decimal? TotalReserva { get; set; }
        public decimal? PrecoComDesconto { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostCalcularTotal()
        {
            int dias = 5;
            int precoPorDia = 100;

            Console.WriteLine($"Teste CalcularTotalReserva: Dias={dias}, PrecoPorDia={precoPorDia}");
            TotalReserva = CalculateDelegate.CalcularTotalReserva(dias, precoPorDia);
            Console.WriteLine($"Resultado: {TotalReserva}");

            return Page();
        }

        public IActionResult OnPostAplicarDesconto()
        {
            Pacote = new PacoteTuristico
            {
                Titulo = "Pacote Brasil",
                Preco = 1000,
                Destinos = new List<Destino>
                {
                    new Destino { Pais = "Brasil" },
                    new Destino { Pais = "Argentina" }
                }
            };

            Console.WriteLine($"PrecoSemDesconto={Pacote.Preco}");
            PrecoComDesconto = CalculateDelegate.AplicarDescontoAmericaSul(Pacote);
            Console.WriteLine($"PrecoComDesconto={PrecoComDesconto}");

            return Page();
        }
    }
}
