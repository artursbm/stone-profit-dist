using Microsoft.AspNetCore.Mvc;

namespace ProfitDistribution.Services.Application
{
    public interface IProfitService
    {
        ActionResult GetSummaryForProfitDistribution(decimal totalAmount);

        ActionResult GetEmployees();
    }
}
