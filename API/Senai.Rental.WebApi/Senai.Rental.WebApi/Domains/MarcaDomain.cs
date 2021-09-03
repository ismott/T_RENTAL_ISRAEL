using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class MarcaDomain
    {

        [JsonIgnore]
        public int MarcaId { get; set; }

        public string NomeMarca { get; set; }

    }
}
