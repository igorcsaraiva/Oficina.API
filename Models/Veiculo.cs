namespace Oficina.API.Models
{
    public class Veiculo : Entidade
    {
        public Veiculo(int id) : base(id)
        {
        }

        public Veiculo(string placa, string? marca, string? modelo, string? cor, int? ano, int clienteId, int id)
        {
            Id = id;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            Ano = ano;
            ClienteId = clienteId;
        }

        public Veiculo(string placa, string? marca, string? modelo, string? cor, int? ano, int clienteId)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            Ano = ano;
            ClienteId = clienteId;
        }

        public string Placa { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Cor { get; set; }
        public int? Ano { get; set; }
        public int ClienteId { get; set; }
        public IList<OrdemServico> OrdemServicos { get; set; }
    }
}
