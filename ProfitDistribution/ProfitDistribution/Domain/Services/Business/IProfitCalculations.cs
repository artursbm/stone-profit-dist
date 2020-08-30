using System.Collections.Generic;
using System.Threading.Tasks;
using ProfitDistribution.Domain.Models;

namespace ProfitDistribution.Domain.Services.Business
{
    public interface IProfitCalculations
    {
        Task<List<EmployeeDistribution>> DistributeProfitForEmployeesAsync(List<Employee> employees);

    }
}