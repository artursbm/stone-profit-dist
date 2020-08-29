﻿using System;
using System.Collections.Generic;
using ProfitDistribution.Domain.Mappers;
using ProfitDistribution.Domain.Models;
using ProfitDistribution.Domain.Models.Profit;
using ProfitDistribution.Domain.Repositories;
using ProfitDistribution.Utils;

namespace ProfitDistribution.Domain.Services.Business
{
    public class ProfitCalculations : IProfitCalculations
    {
        private readonly IDatabaseWeights databaseWeights;
        private readonly IObjectMappers objectMappers;

        public ProfitCalculations(IDatabaseWeights database, IObjectMappers mappers)
        {
            databaseWeights = database;
            objectMappers = mappers;
        }

        public List<EmployeeDistribution> DistributeProfitForEmployees(List<Employee> employees)
        {
            List<EmployeeDistribution> employeeDistributions = new List<EmployeeDistribution>();

            List<PFSModel> pfsList = databaseWeights.FetchAllPFS();
            List<PTAModel> ptaList = databaseWeights.FetchAllPTA();

            employees.ForEach(employee => employeeDistributions.Add(objectMappers.MapEmployeeToEmployeeDistribution(employee, CalculateProfitDistributionForEmployee(employee, pfsList, ptaList))));

            return employeeDistributions;
        }

        private decimal CalculateProfitDistributionForEmployee(Employee employee, List<PFSModel> pfsList, List<PTAModel> ptaList)
        {
            decimal salary = MoneyUtils.SetDecimalFromString(employee.Salary);
            DateTime admissionDate = employee.AdmissionDate;
            string area = employee.Area;
            string position = employee.Position;

            return salary * AppConstants.MONTHS_IN_YEAR * GetEquationResult(salary, admissionDate, area, position, pfsList, ptaList);

        }

        public decimal GetEquationResult(decimal salary, DateTime admissionDate, string area, string position, List<PFSModel> pfsList, List<PTAModel> ptaList)
        {
            return decimal.Divide(decimal.Add(GetPTA(admissionDate, ptaList), GetPAA(area)), GetPFS(salary, position, pfsList));
        }

        private decimal GetPAA(string area)
        {
            return databaseWeights.FetchPAAByArea(area);
        }

        private decimal GetPFS(decimal salary, string position, List<PFSModel> pfsList)
        {
            if (position.Equals(AppConstants.ESTAGIARIO))
            {
                return AppConstants.PESO_UM;
            }
            else
            {
                decimal weight = 0;
                decimal salaryRatio = decimal.ToInt16(decimal.Ceiling(salary / AppConstants.MINIMUM_WAGE));
                pfsList.ForEach(pfs =>
                {
                    if (pfs.MinSalaries < salaryRatio && salaryRatio <= (pfs.MaxSalaries ?? int.MaxValue))
                    {
                        weight = pfs.Weight;
                        return;
                    }
                });
                return weight;
            }
        }

        private decimal GetPTA(DateTime admissionDate, List<PTAModel> ptaList)
        {
            int yearsInCompany = GetYearsInCompany(admissionDate);
            decimal weight = 1;
            ptaList.ForEach(pta =>
            {
                if (pta.MinYears <= yearsInCompany && yearsInCompany < (pta.MaxYears ?? int.MaxValue))
                {
                    weight = pta.Weight;
                    return;
                }
            });
            return weight;
        }

        private int GetYearsInCompany(DateTime admissionDate)
        {
            int yearsInCompany = DateTime.Today.Year - admissionDate.Year;
            if (admissionDate > DateTime.Today.AddYears(-yearsInCompany))
            {
                yearsInCompany--;
            }
            return yearsInCompany;

        }
    }
}
