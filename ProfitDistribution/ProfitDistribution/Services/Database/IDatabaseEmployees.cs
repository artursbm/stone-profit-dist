using System;
using System.Collections.Generic;
using ProfitDistribution.Models;

namespace ProfitDistribution.Services.Database
{
    // This interface could be implemented for firebase or Redis Cloud or other database provider.
    public interface IDatabaseEmployees
    {
        public IList<Employee> FetchListOfEmployees();
    }
}
