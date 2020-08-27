using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProfitDistribution.Models;

namespace ProfitDistribution.Services.Database
{
    public class DatabaseEmployees : IDatabaseEmployees
    {

        private static string FIREBASE_EMPLOYEES_ENDPOINT = "https://stone-profit-dist.firebaseio.com/employees.json";

        IList<Employee> IDatabaseEmployees.FetchListOfEmployees()
        {
            return FetchListOfEmployeesAsync().Result;
        }

        private async Task<IList<Employee>> FetchListOfEmployeesAsync()
        {
            IList<Employee> employees = new List<Employee>();
            var httpClient = new HttpClient();
            using (var response = await httpClient.GetAsync(FIREBASE_EMPLOYEES_ENDPOINT))
            {
                string emps = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<Employee>>(emps);
            }
            return employees;

        }


    }
}
