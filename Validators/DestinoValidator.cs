using AT_C__2.Models;

namespace AT_C__2.Validators
{
    public class DestinoValidator
    {
        public static void ValidarCampos(Destino destino)
        {
            if (string.IsNullOrWhiteSpace(destino.Nome))
                throw new ArgumentException("Nome do destino é obrigatório.");
            if (destino.Nome.Length <=3 )
                throw new ArgumentException("Nome do destino precisa ser mairo que 3 letras");
            if (string.IsNullOrWhiteSpace(destino.Pais))
                throw new ArgumentException("País do destino é obrigatório.");
        }
    }
}
