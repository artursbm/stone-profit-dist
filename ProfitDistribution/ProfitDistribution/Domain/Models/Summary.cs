using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProfitDistribution.Domain.Models
{
    public partial class Summary
    {
        [JsonProperty("participacoes")]
        public List<EmployeeDistribution> Distributions { get; set; }

        [JsonProperty("total_de_funcionarios")]
        public string TotalEmployees { get; set; }

        [JsonProperty("total_distribuido")]
        public string DistributedAmount { get; set; }

        [JsonProperty("total_disponibilizado")]
        public string AvailableAmount { get; set; }

        [JsonProperty("saldo_total_disponibilizado")]
        public string DistributionAmountBalance { get; set; }

    }
}
