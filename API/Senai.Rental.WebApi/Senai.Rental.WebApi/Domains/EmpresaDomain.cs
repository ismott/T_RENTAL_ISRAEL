using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class EmpresaDomain
    {
        [JsonIgnore]
        public int EmpresaId { get; set; }

        public string NomeEmpresa { get; set; }
    }
}
