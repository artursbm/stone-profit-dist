using Microsoft.AspNetCore.Mvc;

namespace ProfitDistribution.Domain.Services.Application
{
    public interface IProfitService
    {
        ActionResult GetSummaryForProfitDistribution(decimal totalAmount);

        ActionResult GetEmployees();
    }
}
