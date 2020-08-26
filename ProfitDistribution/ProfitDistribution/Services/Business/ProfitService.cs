using System;
using System.Collections.Generic;
using ProfitDistribution.Models;
using ProfitDistribution.Services.Database;

namespace ProfitDistribution.Services.Business
{
    public class ProfitService : IProfitService
    {
        private readonly IDatabaseEmployees databaseEmployees;

        public ProfitService(IDatabaseEmployees database)
        {
            databaseEmployees = database;
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>(databaseEmployees.FetchListOfEmployees());
        }
    }
}
