using System.Collections.Generic;
using ProfitDistribution.Models;

namespace ProfitDistribution.Repositories
{
    // This interface could be implemented for firebase or Redis Cloud or other database provider.
    public interface IDatabaseEmployees
    {
        IList<Employee> FetchAllEmployees();
    }
}
