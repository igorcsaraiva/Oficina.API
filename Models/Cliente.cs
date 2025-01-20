
namespace Oficina.API.Models
{
    public class Cliente : Pessoa
    {
        public Cliente(int id) : base(id)
        {
        }

        public Cliente(string cpf,
                       string nome,
                       DateTime? dataNascimento,
                       string? email) : base(cpf, nome, dataNascimento)
        {
            Email = email;
        }

        public Cliente(string cpf,
                       string nome,
                       DateTime? dataNascimento,
                       string? email,
                       int id) : base(cpf, nome, dataNascimento, id)
        {
            Email = email;
        }

        public string? Email { get; set; }
        public IList<Endereco> Enderecos { get; set; } = [];
        public IList<Veiculo> Veiculos { get; set; } = [];
    }
}
