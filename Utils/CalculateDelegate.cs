using AT_C__2.Models;

namespace AT_C__2.Utils
{
    public delegate decimal CalculoDescontoDelegate(PacoteTuristico pacote);

    public static class CalculateDelegate
    {
        public static readonly Func<int, int, decimal> CalcularTotalReserva =
            (dias, precoPorDia) => dias * precoPorDia;

        public static decimal AplicarDescontoAmericaSul(PacoteTuristico pacote)
        {
            String[] destinosAmericaSul = [
                "Brasil", 
                "Argentina", 
                "Uruguai", 
                "Chile", 
                "Paraguai",
                "Venezuela",
                "Guiana",
                "Suriname",
                "Bolívia", 
                "Peru", 
                "Equador", 
                "Colômbia", 
            ];

            bool contemDestinoSulamericano = pacote.Destinos
                .Any(d => destinosAmericaSul.Contains(d.Pais, StringComparer.OrdinalIgnoreCase));

            return contemDestinoSulamericano
                ? pacote.Preco * 0.9m 
                : pacote.Preco;
        }
    }
}
