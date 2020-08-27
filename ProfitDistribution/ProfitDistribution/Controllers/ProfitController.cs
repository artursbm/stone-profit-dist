using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Models;
using ProfitDistribution.Services.Business;

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
        [Route("profit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Summary> CalculateProfitGet([FromQuery] decimal totalAmount)
        {
            return profitService.GetSummaryForProfitDistribution(totalAmount);
        }

        [HttpGet]
        [Route("employees")]
        public ActionResult<List<Employee>> GetEmployeeList()
        {
            return Ok(profitService.GetEmployees());
        }

    }
}
