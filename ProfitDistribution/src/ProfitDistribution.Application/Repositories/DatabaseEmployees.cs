using Newtonsoft.Json;
using ProfitDistribution.Domain.Models;
using ProfitDistribution.Utils;

namespace ProfitDistribution.Application.Repositories
{
    public class DatabaseEmployees : IDatabaseEmployees
    {

        private const string ENDPOINT_EMPLOYEES = "/employees.json";



        public async Task<List<Employee>> FetchAllEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();
            var httpClient = new HttpClient();
            using (HttpResponseMessage response = await httpClient.GetAsync(AppConstants.BASE_URL_DB_FIREBASE + ENDPOINT_EMPLOYEES))
            {
                string emps = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<Employee>>(emps);
            }
            return employees.ToList();

        }


    }
}
