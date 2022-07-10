using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProfitDistribution.Application.Services.Application;
using ProfitDistribution.Domain.Models;
using ProfitDistribution.Presentation.Controllers;
using Xunit;

namespace ProfitDistribution.UnitTests.Controllers
{
    public class ProfitControllerTests
    {
        [Fact]
        public async Task ProfitControllerTest_GetEmployees()
        {
            var mockService = new Mock<IProfitService>();
            mockService.Setup(service => service.GetEmployeesAsync())
                .ReturnsAsync(GetListOfEmployeesMock());
            var controller = new ProfitController(mockService.Object);

            var result = await controller.GetEmployeeListAsync();

            Assert.Equal(2, result.Count);
        }

        [Fact(Skip = "Need to fix this test")]
        public async Task ProfitControllerTest_GetSummary()
        {
            var mockService = new Mock<IProfitService>();
            mockService.Setup(service => service.GetSummaryForProfitDistributionAsync(35000))
                .ReturnsAsync(GetSummaryMock);
            var controller = new ProfitController(mockService.Object);

            var result = await controller.CalculateProfitGetAsync(35000);

            // TODO: fix this test
        }

        private ActionResult GetSummaryMock()
        {
            List<Employee> employees = GetListOfEmployeesMock();
            List<EmployeeDistribution> distributions = new List<EmployeeDistribution>
            {
                new EmployeeDistribution
                {
                    Name = employees.ElementAt(0).Name,
                    RegistrationId = employees.ElementAt(0).RegistrationId,
                    DistributionAmount = "R$ 18.516,00"
                },
                new EmployeeDistribution
                {
                    Name = employees.ElementAt(1).Name,
                    RegistrationId = employees.ElementAt(1).RegistrationId,
                    DistributionAmount = "R$ 14.808,00"
                }
            };

            var summary = new Summary
            {
                Distributions = distributions,
                TotalEmployees = employees.Count.ToString(),
                DistributedAmount = "R$ 33.324,00",
                AvailableAmount = "R$ 35.000,00",
                DistributionAmountBalance = "R$ 1.676,00"
            };

            return new OkObjectResult(summary);
        }

        private List<Employee> GetListOfEmployeesMock()
        {
            return new List<Employee>
            {
                new Employee
                {
                    RegistrationId = "12345",
                    Name = "John Doe",
                    Area = "Diretoria",
                    Position = "Diretor Financeiro",
                    Salary = "R$ 1.234,00",
                    AdmissionDate = DateTime.Parse("2010-08-05")
                },
                new Employee
                {
                    RegistrationId = "67890",
                    Name = "Jane Smith",
                    Area = "Financeiro",
                    Position = "Economista Chefe",
                    Salary = "R$ 1.543,00",
                    AdmissionDate = DateTime.Parse("2009-08-05")
                },
            };
        }
    }
}