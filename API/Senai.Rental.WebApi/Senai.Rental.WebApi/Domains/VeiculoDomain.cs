using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class VeiculoDomain
    {

        [JsonIgnore]
        public int VeiculoId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ModeloDomain Modelo { get; set; }

        [JsonIgnore]
        public int ModeloId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EmpresaDomain Empresa { get; set; }

        [JsonIgnore]
        public int EmpresaId { get; set; }

        public string Placa { get; set; }
    }
}
