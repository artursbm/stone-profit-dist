using Newtonsoft.Json;

namespace ProfitDistribution.Models.Profit
{
    public class PTAModel
    {
        [JsonProperty("minAnos")]
        public int? MinYears { get; set; }

        [JsonProperty("maxAnos")]
        public int? MaxYears { get; set; }

        [JsonProperty("peso")]
        public decimal Weight { get; set; }

    }
}
