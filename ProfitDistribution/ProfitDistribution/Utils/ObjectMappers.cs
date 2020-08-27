using System;
using System.Collections.Generic;
using ProfitDistribution.Models;

namespace ProfitDistribution.Utils
{
    public class ObjectMappers
    {
        public ObjectMappers()
        {
        }

        public Summary MapResultToSummary(List<EmployeeDistribution> employeeDistributions, string numberOfEmployees, decimal totalAmount, decimal totalDistributed, decimal distributionAmountBalance)
        {
            return new Summary
            {
                Distributions = employeeDistributions,
                TotalEmployees = numberOfEmployees,
                DistributedAmount = MoneyUtils.SetMoneyTextFromDecimal(totalDistributed),
                DistributionAmountBalance = MoneyUtils.SetMoneyTextFromDecimal(distributionAmountBalance),
                AvailableAmount = MoneyUtils.SetMoneyTextFromDecimal(totalAmount)
            };
        }


    }
}
