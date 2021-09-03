using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomai> ListaVeiculo = _AluguelRepository.ListarTodas();

            return Ok(ListaVeiculo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomai AluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (AluguelBuscado == null)
            {
                return NotFound("Nehum Veiculo encontrado");
            }
            return Ok(AluguelBuscado);
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, AluguelDomai NovoAluguel)
        {
            AluguelDomai AluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (AluguelBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Aluguel Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _AluguelRepository.AtualizarUrl(id, NovoAluguel);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(AluguelDomai NovoAluguel)
        {
            _AluguelRepository.Cadastrar(NovoAluguel);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);

            return StatusCode(201);
        }
    }
}
