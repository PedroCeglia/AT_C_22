using AT_C__2.Models;

namespace AT_C__2.Validators
{
    public class PacoteTuristicoValidator
    {
        public static void ValidarCampos(PacoteTuristico pacoteTuristico)
        {
            if (string.IsNullOrWhiteSpace(pacoteTuristico.Titulo))
                throw new ArgumentException("Título do pacote é obrigatório.");
            if (pacoteTuristico.DataInicio < DateTime.Today)
                throw new ArgumentException("A data de início não pode ser no passado.");
            if (pacoteTuristico.CapacidadeMaxima <= 0)
                throw new ArgumentException("A capacidade máxima deve ser maior que zero.");
            if (pacoteTuristico.Preco <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");
            if (pacoteTuristico.Destinos == null || !pacoteTuristico.Destinos.Any())
                throw new ArgumentException("O pacote deve conter ao menos um destino.");
        }
    }
}
