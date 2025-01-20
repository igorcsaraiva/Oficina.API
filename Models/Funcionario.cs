namespace Oficina.API.Models
{
    public class Funcionario : Pessoa
    {
        public Funcionario(int id) : base(id)
        {
        }

        public string Senha { get; set; }
        public DateTime? DataContratacao { get; set; }
        public decimal? Salario { get; set; }
        public DateTime? DataDemissao { get; set; }
        public  string NomeCargo { get; set; }
        public IList<OrdemServico> OrdemServicos { get; set; }
    }
}
