using System.Collections.Generic;
using ProfitDistribution.Models.Profit;

namespace ProfitDistribution.Repositories
{
    public interface IDatabaseWeights
    {

        decimal FetchPAAByArea(string area);

        List<PFSModel> FetchAllPFS();

        List<PTAModel> FetchAllPTA();
    }
}
