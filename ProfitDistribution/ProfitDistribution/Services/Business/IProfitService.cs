using System.Collections.Generic;
using ProfitDistribution.Models;

namespace ProfitDistribution.Services.Business
{
    public interface IProfitService
    {
        Summary GetSummaryForProfitDistribution(decimal totalAmount);

        List<Employee> GetEmployees();
    }
}
