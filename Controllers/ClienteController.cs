using Microsoft.AspNetCore.Mvc;
using Oficina.API.DTO;
using Oficina.API.Models;
using Oficina.API.Services;

namespace Oficina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IService<Cliente> _clienteService;

        public ClienteController(IService<Cliente> clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("Inserir")]
        public ActionResult Adicionar([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var cliente = new Cliente(clienteDto.Cpf,clienteDto.Nome, clienteDto.DataDataNascimento, clienteDto.Email);

                var clienteResultado = _clienteService.Adicionar(cliente);
                return Ok(new
                {
                    data = new
                    {
                        clienteResultado
                    }
                }); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao inserir"});
            }
            
        }

        [HttpGet("Buscar/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var cliente = await _clienteService.BuscarPorId(id);

                if (cliente == null)
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
                        cliente
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
                var clientes = await  _clienteService.BuscarTodos();

                return Ok(new
                {
                    data = new
                    {
                        clientes
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
        public ActionResult Atualizar([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var cliente = new Cliente(clienteDto.Cpf, clienteDto.Nome, clienteDto.DataDataNascimento, clienteDto.Email, clienteDto.Id);
                var clienteResultado =  _clienteService.Atualizar(cliente);
                return Ok(new
                {
                    data = new
                    {
                        clienteResultado
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
                var cliente = await _clienteService.BuscarPorId(id);
                if (cliente == null)
                    return NotFound(new
                    {
                        data = new
                        {
                            Mensage = "Recurso nao encontrado"
                        }
                    });

                _clienteService.Remover(cliente);

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
