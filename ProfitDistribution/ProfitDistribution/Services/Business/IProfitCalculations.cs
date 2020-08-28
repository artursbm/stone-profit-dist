using System;
using System.Collections.Generic;
using ProfitDistribution.Models;

namespace ProfitDistribution.Services.Business
{
    public interface IProfitCalculations
    {
        List<EmployeeDistribution> DistributeProfitForEmployees(List<Employee> employees);
    }
}