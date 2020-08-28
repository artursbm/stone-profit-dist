using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProfitDistribution.Models;
using ProfitDistribution.Utils;

namespace ProfitDistribution.Repositories
{
    public class DatabaseEmployees : IDatabaseEmployees
    {

        private const string ENDPOINT_EMPLOYEES = "/employees.json";

        IList<Employee> IDatabaseEmployees.FetchAllEmployees()
        {
            return FetchListOfEmployeesAsync().Result;
        }

        private async Task<IList<Employee>> FetchListOfEmployeesAsync()
        {
            IList<Employee> employees = new List<Employee>();
            var httpClient = new HttpClient();
            using (HttpResponseMessage response = await httpClient.GetAsync(AppConstants.BASE_URL_DB_FIREBASE + ENDPOINT_EMPLOYEES))
            {
                string emps = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<Employee>>(emps);
            }
            return employees;

        }


    }
}
