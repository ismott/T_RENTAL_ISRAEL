using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ModeloDomain
    {

        [JsonIgnore]
        public int ModeloId { get; set; }

        public MarcaDomain Marca { get; set; }

        [JsonIgnore]
        public int MarcaId { get; set; }

        public string NomeModelo { get; set; }
    }
}
