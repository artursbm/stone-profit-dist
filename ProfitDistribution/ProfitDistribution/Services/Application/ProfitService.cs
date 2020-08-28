using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Models;
using ProfitDistribution.Repositories;
using ProfitDistribution.Services.Business;
using ProfitDistribution.Utils;
using ProfitDistribution.Utils.Mappers;

namespace ProfitDistribution.Services.Application
{
    public class ProfitService : IProfitService
    {
        private readonly IDatabaseEmployees databaseEmployees;
        private readonly IProfitCalculations profitCalculations;
        private readonly IObjectMappers objectMappers;

        // Performing Dependency Injection
        public ProfitService(IDatabaseEmployees database, IObjectMappers mappers, IProfitCalculations profitCalcs)
        {
            databaseEmployees = database;
            objectMappers = mappers;
            profitCalculations = profitCalcs;
        }

        public ActionResult GetSummaryForProfitDistribution(decimal totalAmount)
        {
            List<Employee> employees = GetAllEmployees();
            List<EmployeeDistribution> employeeDistributions = profitCalculations.DistributeProfitForEmployees(employees);

            decimal totalDistributed = employeeDistributions.Sum(emp => MoneyUtils.SetDecimalFromString(emp.DistributionAmount));
            decimal distributionAmountBalance = decimal.Subtract(totalAmount, totalDistributed);

            if (IsNegative(distributionAmountBalance))
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(objectMappers.MapResultToSummary(employeeDistributions, employees.Count.ToString(), totalAmount, totalDistributed, distributionAmountBalance));
        }

        public ActionResult GetEmployees()
        {
            try
            {
                return new OkObjectResult(GetAllEmployees());
            }
            catch
            {
                return new BadRequestResult();
            }

        }

        private List<Employee> GetAllEmployees()
        {
            return new List<Employee>(databaseEmployees.FetchAllEmployees());
        }

        private bool IsNegative(decimal distributionAmountBalance)
        {
            return distributionAmountBalance.CompareTo(decimal.Zero) < decimal.Zero;
        }
    }
}
