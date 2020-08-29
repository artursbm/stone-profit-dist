using System.Collections.Generic;
using ProfitDistribution.Domain.Models.Profit;

namespace ProfitDistribution.Domain.Repositories
{
    public interface IDatabaseWeights
    {

        decimal FetchPAAByArea(string area);

        List<PFSModel> FetchAllPFS();

        List<PTAModel> FetchAllPTA();
    }
}
