namespace Oficina.API.DTO
{
    public record FuncionarioDto(string cpf,
                           string nome,
                           DateTime? dataNascimento,
                           int id,
                           string senha,
                           DateTime? dataContratacao,
                           decimal? salario,
                           DateTime? dataDemissao,
                           string nomeCargo);
        
}
