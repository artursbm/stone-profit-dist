using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Domain.Models;

namespace ProfitDistribution.Domain.Services.Application
{
    public interface IProfitService
    {
        Task<ActionResult<Summary>> GetSummaryForProfitDistributionAsync(decimal totalAmount);

        Task<List<Employee>> GetEmployeesAsync();
    }
}
