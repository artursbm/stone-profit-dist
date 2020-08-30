using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Domain.Models;
using ProfitDistribution.Domain.Services.Application;

namespace ProfitDistribution.Controllers
{

    [ApiController]
    [Route("api/profit-dist")]
    public class ProfitController : ControllerBase
    {

        private readonly IProfitService profitService;

        //// adding ProfitService with Dependency Injection so that my service
        //// layer can be instantiated by the application, and I need only to access
        //// it in the controller, decoupling them
        public ProfitController(IProfitService service)
        {
            profitService = service;
        }


        [HttpGet]
        [Route("employees/profit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Summary>> CalculateProfitGetAsync([FromQuery] decimal totalAmount)
        {
            return await profitService.GetSummaryForProfitDistributionAsync(totalAmount);

        }

        [HttpGet]
        [Route("employees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            return await profitService.GetEmployeesAsync();
        }

    }
}
