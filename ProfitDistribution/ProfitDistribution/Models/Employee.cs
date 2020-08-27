using System;
using Newtonsoft.Json;

namespace ProfitDistribution.Models
{

    public class Employee
    {

        [JsonProperty("matricula")]
        public string RegistrationId { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("cargo")]
        public string Position { get; set; }

        [JsonProperty("salario_bruto")]
        public string Salary { get; set; }

        [JsonProperty("data_de_admissao")]
        public DateTime AdmissionDate { get; set; }

    }
}
