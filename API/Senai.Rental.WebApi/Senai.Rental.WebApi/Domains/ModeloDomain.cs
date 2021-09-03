using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ModeloDomain
    {

        public int ModeloId { get; set; }

        public MarcaDomain Marca { get; set; }

        public int MarcaId { get; set; }

        public string NomeModelo { get; set; }
    }
}
