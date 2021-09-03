using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {

        List<AluguelDomai> ListarTodas();

        AluguelDomai BuscarPorId(int IdAluguel);

        void Cadastrar(AluguelDomai NovoAluguel);

        void AtualizarUrl(int IdAluguel, AluguelDomai AluguelAtualizado);

        void Deletar(int IdAluguel);
    }
}
