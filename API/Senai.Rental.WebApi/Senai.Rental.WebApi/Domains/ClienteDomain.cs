using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ClienteDomain
    {

        [JsonIgnore]
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Sobrenome { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CNH { get; set; }

    }
}
