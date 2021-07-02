using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ICM.Tools.WebTools.Extensions;
using Microsoft.Extensions.Logging;


namespace ICM.Tools.WebTools
{
    public class HttpClientService : Abstractions.IHttpClientService
    {
        private readonly ILogger<HttpClientService> _logger;
        
        private HttpClient GetHttpClient(string token)
        {
            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", $"token=\"{token}\"");
            return httpClient;
        }

        public HttpClientService(
            ILogger<HttpClientService> logger)
        => _logger = logger;

        public async Task<T> GetAsync<T>(string url, string relative, string token)
        {
            try
            {
                return await (await GetHttpClient(token).GetAsync($"{url}/{relative}")).GetDataAsync<T>();
            }
            catch (Exception)
            {
                //We should logger error 
                return default;
            }
        }

        public async Task<Out> PostAsync<In, Out>(string url, string relative, In objIn, string token)
        {
            try
            {
                using (var client = GetHttpClient(token))
                    return await (await GetHttpClient(token)
                        .PostAsync(
                            $"{url}/{relative}",
                            objIn.GetStringContent()))
                        .GetDataAsync<Out>();
            }
            catch (Exception)
            {
                //We should logger error 
                return default;
            }
        }
    }
}
