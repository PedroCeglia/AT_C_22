using AT_C__2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages
{
    public class TestePacoteTuristicoModel : PageModel
    {
        private static PacoteTuristico _pacote;
        private static int _reservaIdCounter = 0;

        public string Resultado { get; set; }
        public int ReservasCount => _pacote?.Reservas?.Count ?? 0;

        public void OnGet()
        {
            // Inicializa o pacote apenas na primeira vez
            if (_pacote == null)
            {
                _pacote = new PacoteTuristico
                {
                    Id = 1,
                    Titulo = "Teste",
                    CapacidadeMaxima = 2,
                    Reservas = new List<Reserva>()
                };
                _reservaIdCounter = 0;
                Console.WriteLine("Pacote inicializado");
            }
        }

        public void OnPost()
        {
            bool capacidadeExcedida = false;
            _pacote.CapacityReached += (sender, args) =>
            {
                capacidadeExcedida = true;
                Console.WriteLine("Evento CapacityReached disparado");
            };

            _pacote.AdicionarReserva(new Reserva
            {
                Id = ++_reservaIdCounter,
                ClienteId = 1,
                PacoteTuristicoId = 1,
                DataReserva = DateTime.Now
            });


            Resultado = capacidadeExcedida ? "Capacidade Máxima Excedida!" : $"Reserva adicionada. Total: {_pacote.Reservas.Count}";
        }
    }
}
