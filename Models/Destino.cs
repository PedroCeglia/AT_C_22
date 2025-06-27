using System.ComponentModel.DataAnnotations;

namespace AT_C__2.Models
{
    public class Destino
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do destino é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do destino deve ter mais de 100 letras.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Pais do destino é obrigatório.")]
        public string Pais { get; set; }
    }
}
