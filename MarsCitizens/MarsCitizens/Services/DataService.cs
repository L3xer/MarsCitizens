using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MarsCitizens.Contracts.Services;


namespace MarsCitizens.Services
{
    public class DataService : IDataService
    {
        public async Task<T> GetAsync<T>(string url) where T : new()
        {
            var httpClient = CreateHttpClient();

            try {
                var response = await httpClient.GetStringAsync(url);
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(response));
            } catch {
                return new T();
            }
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
