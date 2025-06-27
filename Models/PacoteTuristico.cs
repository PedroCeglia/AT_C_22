﻿namespace AT_C__2.Models
{
    public class PacoteTuristico
    {
    public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }
        public List<Destino> Destinos { get; set; }

        public List<Reserva> Reservas { get; set; } = new();

        public event EventHandler? CapacityReached;

        public void AdicionarReserva(Reserva reserva)
        {
            Reservas.Add(reserva);

            if (Reservas.Count > CapacidadeMaxima)
            {
                CapacityReached?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
