using System.Collections.Generic;
using System.Linq;
using ProfitDistribution.Models;
using ProfitDistribution.Services.Database;
using ProfitDistribution.Utils;


namespace ProfitDistribution.Services.Business
{
    public class ProfitService : IProfitService
    {
        private readonly IDatabaseEmployees databaseEmployees;
        private readonly ObjectMappers objectMappers;

        public ProfitService(IDatabaseEmployees database, ObjectMappers mappers)
        {
            databaseEmployees = database;
            objectMappers = mappers;
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>(databaseEmployees.FetchListOfEmployees());
        }

        public Summary GetSummaryForProfitDistribution(decimal totalAmount)
        {
            List<Employee> employees = GetEmployees();
            List<EmployeeDistribution> employeeDistributions = DistributeProfitForEmployees(employees);

            decimal totalDistributed = employeeDistributions.Sum(emp => MoneyUtils.SetDecimalFromString(emp.DistributionAmount));
            decimal distributionAmountBalance = decimal.Subtract(totalAmount, totalDistributed);
            // TODO Learn how to handle errors and return correct error code.
            //if (isNegative(distributionAmountBalance))
            //{
            //    throw new HttpResponseException()
            //}
            return objectMappers.MapResultToSummary(employeeDistributions, employees.Count.ToString(), totalAmount, totalDistributed, distributionAmountBalance);
        }



        private List<EmployeeDistribution> DistributeProfitForEmployees(List<Employee> employees)
        {
            List<EmployeeDistribution> employeeDistributions = new List<EmployeeDistribution>();
            employees.ForEach(employee => employeeDistributions.Add(MapEmployeeToEmployeeDistribution(employee)));

            return employeeDistributions;
        }

        private EmployeeDistribution MapEmployeeToEmployeeDistribution(Employee employee)
        {
            return new EmployeeDistribution
            {
                RegistrationId = employee.RegistrationId,
                Name = employee.Name,
                DistributionAmount = MoneyUtils.SetMoneyTextFromDecimal(CalculateProfitDistributionForEmployee(employee))
            };
        }

        private decimal CalculateProfitDistributionForEmployee(Employee employee)
        {
            decimal salary = MoneyUtils.SetDecimalFromString(employee.Salary);
            return decimal.Multiply(salary, AppConstants.MONTHS_IN_YEAR);
        }

        private bool isNegative(decimal distributionAmountBalance)
        {
            return distributionAmountBalance.CompareTo(decimal.Zero) < decimal.Zero;
        }
    }
}
