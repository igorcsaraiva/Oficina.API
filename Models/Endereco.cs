namespace Oficina.API.Models
{
    public class Endereco : Entidade
    {
        public Endereco(int id) : base(id)
        {
        }

        public string? Rua { get; set; }

        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

        public string? Cep { get; set; }

        public string? PontoReferencia { get; set; }

        public string? Telefone { get; set; }
        public  int ClienteId { get; set; }
    }
}
