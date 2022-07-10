using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Domain.Mappers;
using ProfitDistribution.Domain.Models;
using ProfitDistribution.Domain.Repositories;
using ProfitDistribution.Domain.Services.Business;
using ProfitDistribution.Utils;

namespace ProfitDistribution.Domain.Services.Application
{
    public class ProfitService : IProfitService
    {
        private const string ERROR_BALANCE = "Saldo insuficiente para distribuição";
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

        public async Task<ActionResult<Summary>> GetSummaryForProfitDistributionAsync(decimal totalAmount)
        {
            var employees = await GetEmployeesAsync();
            List<EmployeeDistribution> employeeDistributions = await profitCalculations.DistributeProfitForEmployeesAsync(employees.ToList());
            decimal totalDistributed = employeeDistributions.Sum(emp => MoneyUtils.SetDecimalFromString(emp.DistributionAmount));
            decimal distributionAmountBalance = decimal.Subtract(totalAmount, totalDistributed);

            if (IsNegative(distributionAmountBalance))
            {
                return new BadRequestObjectResult(ERROR_BALANCE);
            }

            return objectMappers.MapResultToSummary(employeeDistributions, employees.Count.ToString(), totalAmount, totalDistributed, distributionAmountBalance);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await databaseEmployees.FetchAllEmployeesAsync();
        }

        private bool IsNegative(decimal distributionAmountBalance)
        {
            return distributionAmountBalance.CompareTo(decimal.Zero) < decimal.Zero;
        }
    }
}
