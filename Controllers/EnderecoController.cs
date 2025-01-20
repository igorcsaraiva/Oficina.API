using Microsoft.AspNetCore.Mvc;
using Oficina.API.Models;
using Oficina.API.Services;

namespace Oficina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost("Inserir")]
        public ActionResult Adicionar([FromBody] Endereco endereco)
        {
            try
            {
                var enderecoResultado = _enderecoService.Adicionar(endereco);
                return Ok(new
                {
                    data = new
                    {
                        enderecoResultado
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
                var endereco = await _enderecoService.BuscarPorId(id);

                if (endereco == null)
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
                        endereco
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao buscar" });
            }
        }

        [HttpGet("BuscarEnderecosCliente/{ClienteId}")]
        public async Task<IActionResult> BuscarEnderecosCliente(int ClienteId)
        {
            try
            {
                var enderecos = await _enderecoService.BuscarEnderecosCliente(ClienteId);

                if (enderecos == null)
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
                        enderecos
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
                var enderecos = await _enderecoService.BuscarTodos();

                return Ok(new
                {
                    data = new
                    {
                        enderecos
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
        public ActionResult Atualizar([FromBody] Endereco endereco)
        {
            try
            {
                var enderecoResultado = _enderecoService.Atualizar(endereco);
                return Ok(new
                {
                    data = new
                    {
                        enderecoResultado
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
                var endereco = await _enderecoService.BuscarPorId(id);
                if (endereco == null)
                    return NotFound(new
                    {
                        data = new
                        {
                            Mensage = "Recurso nao encontrado"
                        }
                    });

                _enderecoService.Remover(endereco);

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
