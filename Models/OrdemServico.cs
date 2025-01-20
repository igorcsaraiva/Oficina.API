namespace Oficina.API.Models
{
    public class OrdemServico : Entidade
    {
        public OrdemServico(int id) : base(id)
        {
        }

        public DateTime? DataHoraEntregaVeiculo { get; set; }
        public DateTime? DataHoraInicioServico { get; set; }
        public DateTime? DataHoraFimServico { get; set; }
        public int? Quilometragem { get; set; }
        public decimal? ValorPago { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
