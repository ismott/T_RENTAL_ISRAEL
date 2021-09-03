using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class VeiculoDomain
    {

        public int VeiculoId { get; set; }

        public ModeloDomain Modelo { get; set; }

        public int ModeloId { get; set; }

        public EmpresaDomain Empresa { get; set; }

        public int EmpresaId { get; set; }

        public string Placa { get; set; }
    }
}
