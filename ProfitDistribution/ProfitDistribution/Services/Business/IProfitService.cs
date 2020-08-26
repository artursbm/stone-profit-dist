using System;
using System.Collections.Generic;
using ProfitDistribution.Models;

namespace ProfitDistribution.Services.Business
{
    public interface IProfitService
    {
        List<Employee> GetEmployees();
    }
}
