namespace Oficina.API.Models
{
    public class Funcionario : Pessoa
    {
        public Funcionario(int id) : base(id)
        {
        }

        public Funcionario(string cpf,
                           string nome,
                           DateTime? dataNascimento,
                           int id,
                           string senha,
                           DateTime? dataContratacao,
                           decimal? salario,
                           DateTime? dataDemissao,
                           string nomeCargo) : base(cpf, nome, dataNascimento, id)
        {
            Senha = senha;
            DataContratacao = dataContratacao;
            Salario = salario;
            DataDemissao = dataDemissao;
            NomeCargo = nomeCargo;
        }

        public string Senha { get; set; }
        public DateTime? DataContratacao { get; set; }
        public decimal? Salario { get; set; }
        public DateTime? DataDemissao { get; set; }
        public  string NomeCargo { get; set; }
        public IList<OrdemServico> OrdemServicos { get; set; }
    }
}
