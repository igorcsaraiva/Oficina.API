using Microsoft.AspNetCore.Mvc;
using Oficina.API.DTO;
using Oficina.API.Models;
using Oficina.API.Services;

namespace Oficina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost("Inserir")]
        public ActionResult Adicionar([FromBody] VeiculoDto veiculoDto)
        {
            try
            {
                var veiculo = new Veiculo(veiculoDto.Placa, veiculoDto.Marca, veiculoDto.Modelo, veiculoDto.Cor, veiculoDto.Ano, veiculoDto.ClienteId);
                var veiculoResultado = _veiculoService.Adicionar(veiculo);
                return Ok(new
                {
                    data = new
                    {
                        veiculoResultado
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao inserir" });
            }

        }

        [HttpGet("Buscar/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var veiculo = await _veiculoService.BuscarPorId(id);

                if (veiculo == null)
                    return NotFound(new
                    {
                        data = new
                        {
                            Mensage = "Recurso nao encontrado"
                        }
                    });


                return Ok(new
                {
                    data = new
                    {
                        veiculo
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao buscar" });
            }
        }

        [HttpGet("BuscarVeiculosCliente/{ClienteId}")]
        public async Task<IActionResult> BuscarveiculosCliente(int ClienteId)
        {
            try
            {
                var veiculos = await _veiculoService.BuscarVeiculosCliente(ClienteId);

                if (veiculos == null)
                    return NotFound(new
                    {
                        data = new
                        {
                            Mensage = "Recurso nao encontrado"
                        }
                    });


                return Ok(new
                {
                    data = new
                    {
                        veiculos
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao buscar" });
            }
        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var veiculos = await _veiculoService.BuscarTodos();

                return Ok(new
                {
                    data = new
                    {
                        veiculos
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao buscar" });
            }
        }

        [HttpPut("Atualizar")]
        public ActionResult Atualizar([FromBody] VeiculoDto veiculoDto)
        {
            try
            {
                var veiculo = new Veiculo(veiculoDto.Placa, veiculoDto.Marca, veiculoDto.Modelo, veiculoDto.Cor, veiculoDto.Ano, veiculoDto.ClienteId, veiculoDto.Id);
                var veiculoResultado = _veiculoService.Atualizar(veiculo);
                return Ok(new
                {
                    data = new
                    {
                        veiculoResultado
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao atualizar" });
            }
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var veiculo = await _veiculoService.BuscarPorId(id);
                if (veiculo == null)
                    return NotFound(new
                    {
                        data = new
                        {
                            Mensage = "Recurso nao encontrado"
                        }
                    });

                _veiculoService.Remover(veiculo);

                return Ok(new
                {
                    data = new
                    {
                        Mensage = "Recurso excluido"
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao excluir" });
            }
        }
    }
}
