using System.Threading.Tasks;

namespace ICM.WSI.TaxJar.Services
{
    public class TaxOrderService
    {
        private readonly ConfigTaxJar _configTaxJar;

        public TaxOrderService(
             ConfigTaxJar configTaxJar,
             Tools.WebTools.Abstractions.IHttpClientService httpClient)
        {
            _configTaxJar = configTaxJar;
            _httpClient = httpClient;
        }

        public async Task<Models.TaxJarOrderData> TaxJarByOrderPost(Models.TaxJarOrder input)
            => input == null
            ? default
            : (await _httpClient.PostAsync<Models.TaxJarOrder, Models.TaxJarOrderDataContainer>(_configTaxJar.URL, $"v2/taxes", input, _configTaxJar.Token))?.Tax;
    }
}
}
