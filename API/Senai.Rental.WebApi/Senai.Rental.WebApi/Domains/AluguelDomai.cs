using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomai
    {

        public int AluguelId { get; set; }

        public VeiculoDomain VeiculoId { get; set; }

        public ClienteDomain ClienteId { get; set; }

        public DateTime DataAluguel { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
