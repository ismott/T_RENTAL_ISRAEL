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
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> ListaVeiculo = _VeiculoRepository.ListarTodos();

            return Ok(ListaVeiculo);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscaPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound("Nehum Veiculo encontrado");
            }
            return Ok(VeiculoBuscado);
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, VeiculoDomain NovoVeiculo)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscaPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Veiculo Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _VeiculoRepository.AtualizarPorUrl(id, NovoVeiculo);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain NovoVeiculo)
        {
            _VeiculoRepository.Cadastrar(NovoVeiculo);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _VeiculoRepository.Deletar(id);

            return StatusCode(201);
        }
    }
}
