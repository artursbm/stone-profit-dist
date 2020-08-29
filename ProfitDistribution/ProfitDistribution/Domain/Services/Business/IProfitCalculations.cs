using System.Collections.Generic;
using ProfitDistribution.Domain.Models;

namespace ProfitDistribution.Domain.Services.Business
{
    public interface IProfitCalculations
    {
        List<EmployeeDistribution> DistributeProfitForEmployees(List<Employee> employees);
    }
}