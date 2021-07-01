using System;
using System.Threading.Tasks;
using ICM.Tools.WebTools.Abstractions;
using ICM.WSI.TaxJar.Extensions;

namespace ICM.WSI.TaxJar.Services
{
    public class RateService : Abstractions.IRateService
    {
        private readonly ConfigTaxJar _configTaxJar;
        private readonly IHttpClientService _httpClient;

        public RateService(
            ConfigTaxJar configTaxJar,
           IHttpClientService httpClient)
        {
            _configTaxJar = configTaxJar ?? throw new ArgumentNullException(nameof(configTaxJar));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Models.TaxJarRateData> TaxJarRateLocationGet(Models.TaxJarRate input)
            => input == null
            ? default
            : (await _httpClient.GetAsync<Models.TaxJarRateDataContainer>(
                _configTaxJar.URL,
                input.GetRelative(),
                _configTaxJar.Token))?
            .Rate;
    }
}
