using System.Collections.Generic;

namespace ProfitDistribution.Models
{
    public partial class Summary
    {
        public List<EmployeeDistribution> Distributions { get; set; }

        public string TotalEmployees { get; set; }

        public string DistributedAmount { get; set; }

        public string AvailableAmount { get; set; }

        public string DistributionAmountBalance { get; set; }

    }
}
