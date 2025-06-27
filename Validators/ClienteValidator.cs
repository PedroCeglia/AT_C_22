using System.Text.RegularExpressions;
using AT_C__2.Models;
using AT_C__2.Repositories.Interfaces;

namespace AT_C__2.Validators
{
    public class ClienteValidator
    {
        

        public static void ValidarCampos(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nome))
                throw new ArgumentException("Nome é obrigatório.");
            if (cliente.Nome.Length <= 3)
                throw new ArgumentException("Nome precisa ser maior que 3 letras.");
            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new ArgumentException("Email é obrigatório.");
            if (!Regex.IsMatch(cliente.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email inválido.");
        }

        public static async Task ValidarExclusividade(Cliente cliente, IClienteRepository clienteRepository)
        {
            try
            {
                var clienteExistente = (await clienteRepository.GetAllAsync())
                    .FirstOrDefault(c => c.Email == cliente.Email && c.Id != cliente.Id);
                if (clienteExistente != null)
                {
                    throw new InvalidOperationException($"Existe um usuario com esse email");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro");
            }
        }
    }
}
