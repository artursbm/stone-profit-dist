using ProfitDistribution.Domain.Models.Profit;

namespace ProfitDistribution.Application.Repositories
{
    public interface IDatabaseWeights
    {

        Task<List<PFSModel>> FetchAllPFSAsync();

        Task<List<PTAModel>> FetchAllPTAAsync();

        Task<List<PAAModel>> FetchAllPAAAsync();
    }
}
