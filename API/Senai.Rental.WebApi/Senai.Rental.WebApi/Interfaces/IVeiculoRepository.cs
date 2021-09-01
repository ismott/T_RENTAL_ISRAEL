using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {

        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscaPorId(int IdVeiculo);

        void Cadastrar(VeiculoDomain NovoVeiculo);

        void AtualizarPorUrl(int IdVeiculo, VeiculoDomain VeiculoAtualizado);

        void Deletar(int IdVeiculo);
    }
}
