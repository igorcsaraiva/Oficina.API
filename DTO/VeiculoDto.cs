namespace Oficina.API.DTO
{
    public record VeiculoDto(string Placa, string? Marca, string? Modelo, string? Cor, int? Ano, int ClienteId, int Id );
 
}
