using Microsoft.AspNetCore.Mvc;
using Oficina.API.DTO;
using Oficina.API.Models;
using Oficina.API.Services;

namespace Oficina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IService<Funcionario> _funcionarioService;

        public FuncionarioController(IService<Funcionario> funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost("Inserir")]
        public ActionResult Adicionar([FromBody] FuncionarioDto funcionarioDto)
        {
            try
            {
                var funcionario = new Funcionario(funcionarioDto.cpf,
                                                  funcionarioDto.nome,
                                                  funcionarioDto.dataNascimento,
                                                  funcionarioDto.id,
                                                  funcionarioDto.senha,
                                                  funcionarioDto.dataContratacao,
                                                  funcionarioDto.salario,
                                                  funcionarioDto.dataDemissao,
                                                  funcionarioDto.nomeCargo);

                var funcionarioResultado = _funcionarioService.Adicionar(funcionario);
                return Ok(new
                {
                    data = new
                    {
                        funcionarioResultado
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
                var funcionario = await _funcionarioService.BuscarPorId(id);

                if (funcionario == null)
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
                        funcionario
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
                var funcionarios = await _funcionarioService.BuscarTodos();

                return Ok(new
                {
                    data = new
                    {
                        funcionarios
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
        public ActionResult Atualizar([FromBody] FuncionarioDto funcionarioDto)
        {
            try
            {
                var funcionario = new Funcionario(funcionarioDto.cpf,
                                                  funcionarioDto.nome,
                                                  funcionarioDto.dataNascimento,
                                                  funcionarioDto.id,
                                                  funcionarioDto.senha,
                                                  funcionarioDto.dataContratacao,
                                                  funcionarioDto.salario,
                                                  funcionarioDto.dataDemissao,
                                                  funcionarioDto.nomeCargo);
                var funcionarioResultado = _funcionarioService.Atualizar(funcionario);

                return Ok(new
                {
                    data = new
                    {
                        funcionarioResultado
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
                var funcionario = await _funcionarioService.BuscarPorId(id);
                if (funcionario == null)
                    return NotFound(new
                    {
                        data = new
                        {
                            Mensage = "Recurso nao encontrado"
                        }
                    });

                _funcionarioService.Remover(funcionario);

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
