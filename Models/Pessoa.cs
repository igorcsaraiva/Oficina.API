namespace Oficina.API.Models
{
    public class Pessoa : Entidade
    {
        public Pessoa(int id) : base(id)
        {
        }

        public Pessoa(string cpf, string nome, DateTime? dataNascimento, int id) : base(id)
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public Pessoa(string cpf, string nome, DateTime? dataNascimento)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
