using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomai
    {
        [JsonIgnore]
        public int AluguelId { get; set; }
        
        public VeiculoDomain Veiculo { get; set; }

        [JsonIgnore]
        public int VeiculoId { get; set; }

        public ClienteDomain Cliente { get; set; }

        [JsonIgnore]
        public int ClienteId { get; set; }

        public DateTime DataAluguel { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
