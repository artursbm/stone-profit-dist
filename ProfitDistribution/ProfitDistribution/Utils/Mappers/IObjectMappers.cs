using System.Collections.Generic;
using ProfitDistribution.Models;

namespace ProfitDistribution.Utils.Mappers
{
    public interface IObjectMappers
    {
        Summary MapResultToSummary(List<EmployeeDistribution> employeeDistributions, string numberOfEmployees, decimal totalAmount, decimal totalDistributed, decimal distributionAmountBalance);

        EmployeeDistribution MapEmployeeToEmployeeDistribution(Employee employee, decimal distributionAmount);
    }
}