using AT_C__2.Models;

namespace AT_C__2.Validators
{
    public class ReservaValidator
    {
        public static void ValidarCampos(Reserva reserva)
        {
            if (reserva.ClienteId <= 0)
                throw new ArgumentException("ClienteId é obrigatório e deve ser válido.");
            if (reserva.PacoteTuristicoId <= 0)
                throw new ArgumentException("PacoteTuristicoId é obrigatório e deve ser válido.");
            if (reserva.DataReserva.Date < DateTime.Today)
                throw new ArgumentException("A data da reserva não pode ser no passado.");
        }
    }
}
