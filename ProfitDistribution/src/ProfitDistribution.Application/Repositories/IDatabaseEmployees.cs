using ProfitDistribution.Domain.Models;

namespace ProfitDistribution.Application.Repositories
{
    // This interface could be implemented for firebase or Redis Cloud or other database provider.
    public interface IDatabaseEmployees
    {
        Task<List<Employee>> FetchAllEmployeesAsync();
    }
}
