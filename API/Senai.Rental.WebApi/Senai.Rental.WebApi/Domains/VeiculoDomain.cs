using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class VeiculoDomain
    {

        public int VeiculoId { get; set; }

        public ModeloDomain ModeloId { get; set; }

        public EmpresaDomain EmpresaId { get; set; }

        public string NomeModelo { get; set; }

        public string Placa { get; set; }
    }
}
