using Newtonsoft.Json;

namespace ProfitDistribution.Models.Profit
{
    public class PFSModel
    {
        [JsonProperty("minSalarios")]
        public int? MinSalaries { get; set; }

        [JsonProperty("maxSalarios")]
        public int? MaxSalaries { get; set; }

        [JsonProperty("peso")]
        public decimal Weight { get; set; }

    }
}
