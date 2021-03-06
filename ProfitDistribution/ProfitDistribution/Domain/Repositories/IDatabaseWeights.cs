﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ProfitDistribution.Domain.Models.Profit;

namespace ProfitDistribution.Domain.Repositories
{
    public interface IDatabaseWeights
    {

        Task<List<PFSModel>> FetchAllPFSAsync();

        Task<List<PTAModel>> FetchAllPTAAsync();

        Task<List<PAAModel>> FetchAllPAAAsync();
    }
}
