using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProfitDistribution.Models.Profit;
using ProfitDistribution.Utils;

namespace ProfitDistribution.Repositories
{
    public class DatabaseWeights : IDatabaseWeights
    {
        private const string ENDPOINT_PAA = "/paa.json";
        private const string ENDPOINT_PTA = "/pta.json";
        private const string ENDPOINT_PFS = "/pfs.json";
        private readonly HttpClient httpClient = new HttpClient();

        public decimal FetchPAAByArea(string area)
        {
            return FetchPAAByAreaAsync(area).Result;
        }

        public List<PTAModel> FetchAllPTA()
        {
            return FetchAllPTAAsync().Result;
        }

        public List<PFSModel> FetchAllPFS()
        {
            return FetchAllPFSAsync().Result;
        }

        private async Task<decimal> FetchPAAByAreaAsync(string area)
        {
            string queryByArea = $"?orderBy=\"area\"&equalTo={area}";
            using HttpResponseMessage response = await httpClient.GetAsync(GetFirebaseEndpoint(ENDPOINT_PAA, queryByArea));
            string paa = await response.Content.ReadAsStringAsync();
            PAAModel paaModel = JsonConvert.DeserializeObject<PAAModel>(paa);
            return paaModel.Weight;
        }

        private async Task<List<PTAModel>> FetchAllPTAAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync(GetFirebaseEndpoint(ENDPOINT_PTA, null));
            string pta = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PTAModel>>(pta);

        }


        private async Task<List<PFSModel>> FetchAllPFSAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync(GetFirebaseEndpoint(ENDPOINT_PFS, null));
            string pfs = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PFSModel>>(pfs);
        }


        private string GetFirebaseEndpoint(string endpoint, string query)
        {
            if (query == null)
            {
                return AppConstants.BASE_URL_DB_FIREBASE + endpoint;
            }
            return AppConstants.BASE_URL_DB_FIREBASE + endpoint + query;
        }


    }
}
