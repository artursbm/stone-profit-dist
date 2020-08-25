using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Models;

namespace ProfitDistribution
{
    [Route("api/profit")]
    public class ProfitController : ControllerBase
    {
       
        [HttpGet]
        public Summary CalculateProfitGet(double availableAmount)
        {
            return new Summary();
        }

    }
}
