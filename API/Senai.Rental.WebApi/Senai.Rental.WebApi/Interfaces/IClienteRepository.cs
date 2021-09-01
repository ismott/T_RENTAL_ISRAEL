using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    {

        List<ClienteDomain> ListarTodas();

        ClienteDomain BuscarPorId(int IdCliente);

        void Cadastrar(ClienteDomain NovoCliente);

        void AtualizarUrl(int IdCliente, ClienteDomain ClienteAtualizado);

        void Deletar(int IdCliente);
    }
}
